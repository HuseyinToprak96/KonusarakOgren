using AutoMapper;
using HtmlAgilityPack;
using KonusarakOgren.Dtos;
using KonusarakOgren.Filters;
using KonusarakOgren.Interfaces.Services;
using KonusarakOgren.Models;
using KonusarakOgren.ViewModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace KonusarakOgren.Controllers
{
    [AllowAnonymous]
    public class ExamController : Controller
    {
        private Uri _url;
        private string _html;
        //public string[][][] MyProperty { get; set; }
        public static string[] Titles = new string[5];
        public static string[] Links = new string[5];
        public static string[] Contents = new string[5];

        public void TitleGet(string Url, string xPath, int i)
        {
            _url = new Uri(Url);
            WebClient client = new WebClient();
            _html = client.DownloadString(_url);
            HtmlAgilityPack.HtmlDocument document = new HtmlAgilityPack.HtmlDocument();
            document.LoadHtml(_html);
            Titles[i]= document.DocumentNode.SelectSingleNode(xPath).InnerText;
            ViewBag.Titles = Titles;
        }
        public void LinkGet(string Url, string xPath, string tag, int i)
        {
            _url = new Uri(Url);
            WebClient client = new WebClient();
            client.Encoding = Encoding.UTF8;
            _html = client.DownloadString(_url);
            HtmlAgilityPack.HtmlDocument document = new HtmlAgilityPack.HtmlDocument();
            document.LoadHtml(_html);
            Links[i] = document.DocumentNode.SelectSingleNode(xPath).Attributes[tag].Value;
            ViewBag.Links = Links;
        }
        public void ContentGet(string link,string xPath, int i)
        {
            
            _url = new Uri(link);
            WebClient client = new WebClient();
            client.Encoding = Encoding.UTF8;
            _html = client.DownloadString(_url);
            HtmlAgilityPack.HtmlDocument document = new HtmlAgilityPack.HtmlDocument();
            document.LoadHtml(_html);
            HtmlNode htmlNode = document.DocumentNode.SelectSingleNode(xPath);
            if (htmlNode == null)
            {
                if (i ==0) 
                htmlNode = document.DocumentNode.SelectSingleNode("/html[1]/body[1]/div[1]/div[1]/main[1]/article[1]/div[2]/div[1]/div[1]/div[1]/div[1]/div[1]/div[1]/div[1]/div[1]/p[1]");
                else
                 htmlNode=document.DocumentNode.SelectSingleNode("/html[1]/body[1]/div[1]/div[1]/main[1]/article[1]/div[2]/div[1]/div[1]/div[1]/div[1]/div[1]/div[1]/p[2]");
                
                
                if (htmlNode != null)
                    Contents[i] = htmlNode.InnerText;
                else
                     Contents[i]="Like most parents, I try to limit my kid's screen time. But screens are so ubiquitous that it's sometimes hard for me to grasp how thoroughly they have infiltrated my kids.";
                ViewBag.Paragraphs = Contents;
            }

        }
        string lnk = "https://www.wired.com";


        private readonly IExamService  _service;
        private readonly IService<Student_Exams> _StudentExamService;
        private readonly IMapper _mapper;

        public ExamController(IExamService service, IMapper mapper, IService<Student_Exams> studentExamService)
        {
            _service = service;
            _mapper = mapper;
            _StudentExamService = studentExamService;
        }
        [FilterTeacherControl]
        public IActionResult CreateExam()
        {
            for (int i = 0; i < 5; i++)
            {
                TitleGet(lnk, "/html[1]/body[1]/div[1]/div[1]/main[1]/div[1]/div[1]/section[1]/div[3]/div[1]/div[1]/div[1]/div[1]/div[" + (i + 1) + "]/div[2]/a[1]/h2[1]", i);//SelectorsHub kullanımı "abs Xpath"
                LinkGet(lnk, "/html[1]/body[1]/div[1]/div[1]/main[1]/div[1]/div[1]/section[1]/div[3]/div[1]/div[1]/div[1]/div[1]/div[" + (i + 1) + "]/div[2]/a[1]", "href", i);
            }

            for (int i = 0; i < 5; i++)
            {
                string Link = lnk + Links[i].ToString();
                ContentGet(Link, "/html/body/div[1]/div/main/article/div[2]/div/div[1]/div/div[1]/p[1]", i);
            }
            return View();
        }

        [HttpPost]
        [AutoValidateAntiforgeryToken]
        public async Task<IActionResult> CreateExam(Exam exam)
        {

              exam.ExamTitle=Titles[exam.Indis];
              exam.ExamParagraph = Contents[exam.Indis];
              exam.TeacherId = 1;//sessiondan gelcek
            if (ModelState.IsValid)
            {
            await _service.AddAsync(exam);
            }
            
            return  RedirectToAction("List");
        }

        //public async Task<IActionResult> Exam(Exam exam)
        //{
        //    exam.ExamTitle = Titles[exam.Indis];
        //    exam.ExamParagraph = Contents[exam.Indis];
        //    exam.TeacherId = 1;
        //    await _service.AddAsync(exam);
        //   // exam.Questions[0].exam;
        //    return View(exam);
        //}

        [FilterLogin]
        [FilterStudentControl]
        public async Task<IActionResult> List()
        {
            int id =(int)HttpContext.Session.GetInt32("ID");//Öğrenciye ait sınavlar için.
            var examList = await _service.StudentwithExams(id);
            return View(examList);
        }
        [FilterTeacherControl]
        public async Task<IActionResult> Delete(int id)
        {
            await _service.removeAsync(id);
            return RedirectToAction("List");
        }

        [FilterTeacherControl]
        public async Task<IActionResult> ExamStudentList()
        {
            int id =(int)HttpContext.Session.GetInt32("ID");
            return View( await _service.ExamStudentList(id));
        }
        [FilterStudentControl]
        public async Task<IActionResult> Start(int id)
        {
            return View(await _service.ExamDetail(id));
        }

        public async Task<JsonResult> Finish(int id)
        {

            return Json(await _service.ExamwithQuestion(id));
        }
        //[HttpPost]
        [FilterStudentControl]
        public async Task ExamFinished(int totalTrue, int totalFalse,int examId,int totalQuestion)//sınav sonucunu kıyaslama metodu
        {

            int id = (int)HttpContext.Session.GetInt32("ID");
            Student_Exams student_Exams = new Student_Exams();
            student_Exams.StudentsId = id;
            student_Exams.TotalTrue = totalTrue;
            student_Exams.TotalFalse = totalFalse;
            student_Exams.Point =totalTrue  * 25;
            student_Exams.IsEntry = true;
            student_Exams.ExamId = examId;
            await _StudentExamService.AddAsync(student_Exams);
        }
        [FilterTeacherControl]
        public string ExamSelected(int id)
        {
            return (Contents[id]);
        }

    }
}
