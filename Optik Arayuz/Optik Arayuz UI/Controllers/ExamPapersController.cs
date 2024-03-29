﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.V4.Pages.Account.Internal;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.CodeAnalysis.Operations;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Newtonsoft.Json.Linq;
using Optik_Arayuz_UI.Data;
using Optik_Arayuz_UI.Models;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Optik_Arayüz_UI.Controllers
{
    public class ExamPapersController : Controller
    {
        private readonly OptikArayuzDbContext _context;

        public ExamPapersController(OptikArayuzDbContext context)
        {
            ComponentsPartial componentsPartial = new ComponentsPartial(context);
            _context = context;
        }
        [Authorize]

        public IActionResult ExamPaperCreate(int? id)
        {
            clear();
            if (id != null)
            {
                ViewBag.Id = id;
            }
            return View();

        }

        [HttpPost]
        public IActionResult ExamPaperCreate(ExamPaper examPaper)
        {
            if (ModelState.IsValid) {
                _context.ExamPapers.Add(examPaper);

                _context.SaveChanges();
            }
           
            return View();

        }
        public bool ExamPaperCopy(int? id)
        {
            //Sınav Kağıdını Kopyalama işlemini gerçekleştiren fonksiyon.

            //Öncelikle kopyalanan kağıdın nameine Kopya ibaresi eklenerek yeniden ekleniyor ve Idsi alınıyor.
            var exampaper = _context.ExamPapers.First(m => m.ExamPaperId == id);
            exampaper.ExamPaperId = 0;
            exampaper.ExamPaperName = exampaper.ExamPaperName + " Kopya";

            _context.ExamPapers.Add(exampaper);
            _context.SaveChanges();
            var paperId = _context.ExamPapers.OrderBy(m => m.ExamPaperId).Last().ExamPaperId;
            //Kopyalanacak kağıdın bütün elementleri getiriliyor.
            var elements = _context.ExamPaperElements.Where(m => m.ExamPaperId == id).ToList();
            //Her elementin sınav kağıdı Idsi yeni ıd ile güncellenerek tekrardan ekleniyor.
            foreach (var element in elements) { 
                element.ExamPaperElementId = 0;
                element.ExamPaperId = paperId;
                _context.ExamPaperElements.Add(element);
            }
            _context.SaveChanges();
            //Her Elementin belirttiği componentler getirtilip onlarda kopyalanıyor. Yeni ıdleri examPapersElements kayıtınında yerini alıyor.
            var components = _context.ExamPaperElements.Where(m => m.ExamPaperId == paperId).ToList();
            foreach (var component in components) {
                switch (component.Type)
                {
                    case "Choice":
                        var a = _context.Choices.First(m => m.ChoiceId == component.ComponentId);
                        a.ChoiceId = 0;
                        _context.Choices.Add(a);
                        _context.SaveChanges();
                        var componentId = _context.Choices.OrderBy(m => m.ChoiceId).Last().ChoiceId;
                        component.ComponentId = componentId;
                        break;

                    case "Logo":
                        var b = _context.Logos.First(m => m.LogoId == component.ComponentId);
                        b.LogoId = 0;
                        _context.Logos.Add(b);
                        _context.SaveChanges();
                        var logoId = _context.Logos.OrderBy(m => m.LogoId).Last().LogoId;
                        component.ComponentId = logoId;
                        break;
                    case "Number":
                        var c = _context.Numbers.First(m => m.NumberId == component.ComponentId);
                        c.NumberId = 0;
                        _context.Numbers.Add(c);
                        _context.SaveChanges();
                        var numberId = _context.Numbers.OrderBy(m => m.NumberId).Last().NumberId;
                        component.ComponentId = numberId;
                        break;

                    case "Student":
                        var d = _context.Students.First(m => m.StudentId == component.ComponentId);
                        d.StudentId = 0;
                        _context.Students.Add(d);
                        _context.SaveChanges();
                        var studentId = _context.Students.OrderBy(m => m.StudentId).Last().StudentId;
                        component.ComponentId = studentId;
                        break;

                    case "Grade":
                        var e = _context.Grades.First(m => m.GradeId == component.ComponentId);
                        e.GradeId = 0;
                        _context.Grades.Add(e);
                        _context.SaveChanges();
                        var gradeId = _context.Grades.OrderBy(m => m.GradeId).Last().GradeId;
                        component.ComponentId = gradeId;
                        break;

                    case "Text":
                        var f = _context.Texts.First(m => m.TextId == component.ComponentId);
                        f.TextId = 0;
                        _context.Texts.Add(f);
                        _context.SaveChanges();
                        var textId = _context.Texts.OrderBy(m => m.TextId).Last().TextId;
                        component.ComponentId = textId;
                        break;

                    case "Test":
                        var g = _context.Tests.First(m => m.TestId == component.ComponentId);
                        g.TestId = 0;
                        _context.Tests.Add(g);
                        _context.SaveChanges();
                        var testId = _context.Tests.OrderBy(m => m.TestId).Last().TestId;
                        component.ComponentId = testId;
                        break;

                    default:
                        break;
                }
                _context.ExamPaperElements.Update(component);
                _context.SaveChanges();

            }
            return true;

        }
        public int CreateNewComponent(string type, int index)
        {
            //Elementin  kendi tablosunda yeni kayıt oluşturma fonksiyonu. Oluşturduktan sonra İd bilgisi geri döndürülür.
            switch (type)
            {
                case "Choice":
                    _context.Choices.Add(ComponentsPartial._choices[index]);
                    _context.SaveChanges();

                    return _context.Choices.OrderBy(m => m.ChoiceId).Last().ChoiceId;
                case "Logo":
                    _context.Logos.Add(ComponentsPartial._logos[index]);
                    _context.SaveChanges();

                    return _context.Logos.OrderBy(m => m.LogoId).Last().LogoId;
                case "Number":
                    _context.Numbers.Add(ComponentsPartial._numbers[index]);
                    _context.SaveChanges();

                    return _context.Numbers.OrderBy(m => m.NumberId).Last().NumberId;
                case "Student":
                    _context.Students.Add(ComponentsPartial._students[index]);
                    _context.SaveChanges();

                    return _context.Students.OrderBy(m => m.StudentId).Last().StudentId;

                case "Grade":
                    _context.Grades.Add(ComponentsPartial._grades[index]);
                    _context.SaveChanges();

                    return _context.Grades.OrderBy(m => m.GradeId).Last().GradeId;
                case "Text":
                    _context.Texts.Add(ComponentsPartial._texts[index]);
                    _context.SaveChanges();

                    return _context.Texts.OrderBy(m => m.TextId).Last().TextId;
                case "Test":
                    _context.Tests.Add(ComponentsPartial._tests[index]);
                    _context.SaveChanges();

                    return _context.Tests.OrderBy(m => m.TestId).Last().TestId;
                default:
                    return 0;


            }
        }
        public bool CreateNewExamPaper(string[] components)
        {
            var paperId = _context.ExamPapers.OrderBy(m => m.ExamPaperId).Last().ExamPaperId;
            int id = 0;
            //Her elementin öncelikle kendi tablosunda yeni kaydı oluşturulur. Daha sonra ExamPaperElements tablosunda yeni kayıt oluşturularak konum ve tür bilgileri kaydedilir.
            //Yeni kayıta sınavKağıdı id bilgisi verilerek kağıtların elementleri oluşturulur.
            for (int i = 0; i < components.Length; i++)
            {
                var attr = components[i].Split("_");
                int index = Convert.ToInt32(attr[0].Substring(attr[0].Length - 1));
                var type = attr[0][..^1];
                //Elementin  kendi tablosunda yeni kayıt oluşturma fonksiyonu. Oluşturduktan sonra İd bilgisi geri döndürülür.
                id = CreateNewComponent(type, index);

                ExamPaperElement examPaperElement = new ExamPaperElement()
                {
                    Type = type,
                    X = Convert.ToDouble(attr[1]),
                    Y = Convert.ToDouble(attr[2]),
                    ExamPaperId = paperId,
                    ComponentId = id,
                };
                _context.ExamPaperElements.Add(examPaperElement);
                _context.SaveChanges();

            }
            return true;
        }
        public string SendDatabase(string value)
        {
            //Elementleri Veritabanına gönderen fonksiyon. Eğer başında id var ise edit sayfasıdır. Yok ise yeni oluşturulmuştur. Farklı işlemler yapılacaktır.
            string[] components = value.Split("/");
            if (components[0].Contains('+'))
            {
                //İd var ise
                editDatabase(components);
            }
            else
            {
                //İd yok ise
                CreateNewExamPaper(components);
            }
            clear();
            return "true";
        }
        public bool editDatabase(string[] components)
        {
            //ExamPaperId bulunarak veritabanından eski element değerleri getiriliyor.
            var paperId = Convert.ToInt32(components[0][..^1]);
            var examPaperElements = _context.ExamPaperElements.Where(m => m.ExamPaperId == paperId).ToList();

            string[] copy = (string[])components.Clone();
            copy = copy.Skip(1).ToArray();
            //Veritabanındaki her element için işlem yapılıyor.
            foreach (var x in examPaperElements)
            {
                bool flag = true;
                //Gönderilen Her element için işlem yapılıyor.
                for (int i = 0; i < copy.Length; i++)
                {
                    //Element özellikleri gönderilen valueden parse ediliyor.
                    var attr = copy[i].Split("_");
                    int index = Convert.ToInt32(attr[0].Substring(attr[0].Length - 1));
                    var type = attr[0][..^1];
                    //Eğer veritabanındaki element ile valuedeki elementtin tipi aynı ise edit vardır. Component türüne göre atamalar yapılıp veritabanı güncellenir.
                    if (type == x.Type)
                    {
                        flag = false;
                        x.X = Convert.ToDouble(attr[1]);
                        x.Y = Convert.ToDouble(attr[2]);
                        switch (type)
                        {
                            case "Choice":
                                var choice = _context.Choices.Where(m => m.ChoiceId == x.ComponentId).First();
                                choice.XLength = ComponentsPartial._choices[index].XLength;
                                choice.YLength = ComponentsPartial._choices[index].YLength;
                                choice.Choices = ComponentsPartial._choices[index].Choices;
                                choice.ChoiceCount = ComponentsPartial._choices[index].ChoiceCount;
                                _context.Update(choice);
                                break;
                            case "Logo":
                                var logo = _context.Logos.Where(m => m.LogoId == x.ComponentId).First();
                                logo.XLength = ComponentsPartial._logos[index].XLength;
                                logo.YLength = ComponentsPartial._logos[index].YLength;
                                logo.ImagePath = ComponentsPartial._logos[index].ImagePath;
                                _context.Update(logo);

                                break;
                            case "Number":
                                var number = _context.Numbers.Where(m => m.NumberId == x.ComponentId).First();
                                number.XLength = ComponentsPartial._numbers[index].XLength;
                                number.YLength = ComponentsPartial._numbers[index].YLength;
                                number.Length = ComponentsPartial._numbers[index].Length;
                                number.Label = ComponentsPartial._numbers[index].Label;
                                number.Columns = ComponentsPartial._numbers[index].Columns;
                                number.Values = ComponentsPartial._numbers[index].Values;
                                _context.Update(number);
                                break;
                            case "Student":
                                var student = _context.Students.Where(m => m.StudentId == x.ComponentId).First();
                                student.XLength = ComponentsPartial._students[index].XLength;
                                student.YLength = ComponentsPartial._students[index].YLength;
                                _context.Update(student);
                                break;
                            case "Grade":
                                var grades = _context.Grades.Where(m => m.GradeId == x.ComponentId).First();
                                grades.XLength = ComponentsPartial._grades[index].XLength;
                                grades.YLength = ComponentsPartial._grades[index].YLength;
                                grades.QuestionCount = ComponentsPartial._grades[index].QuestionCount;
                                _context.Update(grades);
                                break;
                            case "Text":
                                var text = _context.Texts.Where(m => m.TextId == x.ComponentId).First();
                                text.TextContent = ComponentsPartial._texts[index].TextContent;
                                text.FontSize = ComponentsPartial._texts[index].FontSize;
                                text.FontType = ComponentsPartial._texts[index].FontType;
        
                                _context.Update(text);
                                break;
                            case "Test":
                                var test = _context.Tests.Where(m => m.TestId == x.ComponentId).First();
                                test.XLength = ComponentsPartial._tests[index].XLength;
                                test.YLength = ComponentsPartial._tests[index].YLength;
                                test.QuestionCount = ComponentsPartial._tests[index].QuestionCount;
                                test.BreakPoint = ComponentsPartial._tests[index].BreakPoint;
                                _context.Update(test);
                                break;
                            default:
                                break;

                        }
                        _context.Update(x);
                        _context.SaveChanges();
                        //İşlem yapılan veri copyden silinir.
                        copy = copy.Skip(1).ToArray();
                        break;
                    }

                }
                //Copy valuesundaki değerler veritabanındaki değerlerle eşit değilse delete işlemi yapılmıştır. Belirlenen Componentler veri tabanından silinir.
                if (flag)
                {
                    switch (x.Type)
                    {
                        case "Choice":
                            var choice = _context.Choices.Where(m => m.ChoiceId == x.ComponentId).First();
                            _context.Choices.Remove(choice);
                            break;
                        case "Logo":
                            var logo = _context.Logos.Where(m => m.LogoId == x.ComponentId).First();
                            _context.Logos.Remove(logo);

                            break;
                        case "Number":
                            var number = _context.Numbers.Where(m => m.NumberId == x.ComponentId).First();
                            _context.Numbers.Remove(number);

                            break;
                        case "Student":
                            var student = _context.Students.Where(m => m.StudentId == x.ComponentId).First();
                            _context.Students.Remove(student);

                            break;
                        case "Grade":
                            var grade =_context.Grades.Where(m => m.GradeId == x.ComponentId).First();
                            _context.Grades.Remove(grade);
                        
                            break;
                        
                        case "Text":
                            var text = _context.Texts.Where(m => m.TextId == x.ComponentId).First();
                            _context.Texts.Remove(text);

                            break;
                        case "Test":
                            var test = _context.Tests.Where(m => m.TestId == x.ComponentId).First();
                            _context.Tests.Remove(test);

                            break;
                        default:
                            break;

                    }
                    _context.ExamPaperElements.Remove(x);
                    _context.SaveChanges();

                }

            }
            //Bütün işlem bittiğinde elimizde element valuesu kaldıysa yeni element eklenmiştir. Türüne göre yeni ExamPaperElement kayıtları eklenir.
            if (copy.Length > 0)
            {
                for (int i = 0; i < copy.Length; i++)
                {
                    var attr = copy[i].Split("_");
                    int index = Convert.ToInt32(attr[0].Substring(attr[0].Length - 1));
                    var type = attr[0][..^1];

                    int id = CreateNewComponent(type, index);

                    ExamPaperElement examPaperElement = new ExamPaperElement()
                    {
                        Type = type,
                        X = Convert.ToDouble(attr[1]),
                        Y = Convert.ToDouble(attr[2]),
                        ExamPaperId = paperId,
                        ComponentId = id,
                    };
                    _context.ExamPaperElements.Add(examPaperElement);
                    _context.SaveChanges();

                }
            }

            return true;
        }
        public void clear()
        {
            //Componentlerin defaultlar dışındaki silen fonksiyon.
            ComponentsPartial._choices.RemoveRange(1, ComponentsPartial._choices.Count - 1);
            ComponentsPartial._logos.RemoveRange(1, ComponentsPartial._logos.Count - 1);
            ComponentsPartial._numbers.RemoveRange(1, ComponentsPartial._numbers.Count - 1);
            ComponentsPartial._grades.RemoveRange(1, ComponentsPartial._grades.Count-1);
            ComponentsPartial._texts.RemoveRange(1, ComponentsPartial._texts.Count - 1);
            ComponentsPartial._tests.RemoveRange(1, ComponentsPartial._tests.Count - 1);
            ComponentsPartial._students.RemoveRange(1, ComponentsPartial._students.Count - 1);
        }

        public string getExamPaperComponents(int id)
        {
            //Sınav Kağıdı Id si olan bütün ExamPaperElementsler getiriliyor.
            var examPaperElements = _context.ExamPaperElements.Where(m => m.ExamPaperId == id).ToList();

            string values = "";

            foreach (var x in examPaperElements)
            {
                //Her elementin tipine göre işlem yapılıyor. Component idsine göre component özellikleri getirilip statik değişkenlere ekleniyor.
                switch (x.Type)
                {
                    case "Choice":
                        Choice choice = _context.Choices.Where(m => m.ChoiceId == x.ComponentId).FirstOrDefault();
                        ComponentsPartial._choices.Add(choice);
                        values = values + "/" + x.Type + "_" + x.X + "_" + x.Y;
                        break;
                    case "Logo":
                        Logo logo = _context.Logos.Where(m => m.LogoId == x.ComponentId).FirstOrDefault();
                        ComponentsPartial._logos.Add(logo);
                        values = values + "/" + x.Type + "_" + x.X + "_" + x.Y;

                        break;
                    case "Number":
                        Optik_Arayuz_UI.Models.Number number = _context.Numbers.Where(m => m.NumberId == x.ComponentId).FirstOrDefault();
                        ComponentsPartial._numbers.Add(number);
                        values = values + "/" + x.Type + "_" + x.X + "_" + x.Y;

                        break;
                    case "Student":
                        Student student = _context.Students.Where(m => m.StudentId == x.ComponentId).FirstOrDefault();
                        ComponentsPartial._students.Add(student);
                        values = values + "/" + x.Type + "_" + x.X + "_" + x.Y;

                        break;
                    case "Grade":
                        Grade grade = _context.Grades.Where(m => m.GradeId == x.ComponentId).FirstOrDefault();
                        ComponentsPartial._grades.Add(grade);
                        values = values + "/" + x.Type+"_"+x.X+"_"+x.Y;

                        break;
                    case "Text":
                        Text text = _context.Texts.Where(m => m.TextId == x.ComponentId).FirstOrDefault();
                        ComponentsPartial._texts.Add(text);
                        values = values + "/" + x.Type + "_" + x.X + "_" + x.Y;

                        break;
                    case "Test":
                        Test test = _context.Tests.Where(m => m.TestId == x.ComponentId).FirstOrDefault();
                        ComponentsPartial._tests.Add(test);
                        values = values + "/" + x.Type + "_" + x.X + "_" + x.Y;

                        break;
                    default:
                        break;

                }

            }
            if (values.Length > 0)
            {
                values = values.Substring(1);
            }
            return (values);
        }


        [HttpPost]
        public async Task<IActionResult> UploadLogo(string index)
        {
            //Logo Componentinin yeni logo yükleme fonksiyonu
            if (Request.Form.Files.Count > 0)
            {
                var fileName = Path.GetFileName(Request.Form.Files[0].FileName);
                var filePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/UploadedLogoImage/", fileName);
                ComponentsPartial._logos[Convert.ToInt32(index)].ImagePath = fileName;
                using (var fileSrteam = new FileStream(filePath, FileMode.Create))
                {
                    await Request.Form.Files[0].CopyToAsync(fileSrteam);
                }
                ViewBag.Message = "Başarılı";

                return Ok();
            }
            return Ok();



        }
        // GET: ExamPapers
        [Authorize]
        public async Task<IActionResult> Index()
        {
            return _context.ExamPapers != null ?
                        View(await _context.ExamPapers.ToListAsync()) :
                        Problem("Entity set 'OptikArayuzDbContext.ExamPapers'  is null.");
        }


        // GET: ExamPapers/Details/5
        [Authorize]
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.ExamPapers == null)
            {
                return NotFound();
            }

            var examPaper = await _context.ExamPapers
                .FirstOrDefaultAsync(m => m.ExamPaperId == id);
            if (examPaper == null)
            {
                return NotFound();
            }

            return PartialView(examPaper);
        }

        // GET: ExamPapers/Create
        [Authorize]
        public IActionResult Create()
        {
            return View();
        }


        // POST: ExamPapers/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize]
        public async Task<IActionResult> Create([Bind("ExamPaperId,ExamPaperName,ExamPaperTitle")] ExamPaper examPaper)
        {
            if (ModelState.IsValid)
            {
                _context.Add(examPaper);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(examPaper);
        }

        // GET: ExamPapers/Edit/5
        [Authorize]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.ExamPapers == null)
            {
                return NotFound();
            }

            var examPaper = await _context.ExamPapers.FindAsync(id);
            if (examPaper == null)
            {
                return NotFound();
            }
            return PartialView(examPaper);
        }

        // POST: ExamPapers/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize]
        public async Task<IActionResult> Edit(int id, [Bind("ExamPaperId,ExamPaperName,ExamPaperTitle")] ExamPaper examPaper)
        {
            if (id != examPaper.ExamPaperId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(examPaper);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ExamPaperExists(examPaper.ExamPaperId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return PartialView(examPaper);
        }

        // GET: ExamPapers/Delete/5
        [Authorize]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.ExamPapers == null)
            {
                return NotFound();
            }

            var examPaper = await _context.ExamPapers
                .FirstOrDefaultAsync(m => m.ExamPaperId == id);
            if (examPaper == null)
            {
                return NotFound();
            }

            return PartialView(examPaper);
        }

        // POST: ExamPapers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Authorize]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.ExamPapers == null)
            {
                return Problem("Entity set 'OptikArayuzDbContext.ExamPapers'  is null.");
            }
            var examPaper = await _context.ExamPapers.FindAsync(id);
            if (examPaper != null)
            {
                _context.ExamPapers.Remove(examPaper);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ExamPaperExists(int id)
        {
            return (_context.ExamPapers?.Any(e => e.ExamPaperId == id)).GetValueOrDefault();
        }
    }
}
