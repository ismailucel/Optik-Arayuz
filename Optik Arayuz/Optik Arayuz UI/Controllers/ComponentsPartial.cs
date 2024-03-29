﻿using Azure;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Migrations.Operations.Builders;
using Optik_Arayuz_UI.Data;
using Optik_Arayuz_UI.Models;
using System;
using System.Numerics;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Optik_Arayüz_UI.Controllers
{
    //Exam Paperdaki Componentleri yöneten Controller. Her Componentin ayrı css ve cshtmlleri mevcuttur.
    public class ComponentsPartial : Controller
    {
        public static List<Choice>? _choices;
        public static List<Logo>? _logos;
        public static List<Optik_Arayuz_UI.Models.Number>? _numbers;
        public static List<Grade>? _grades;
        public static List<Text>? _texts;
        public static List<Test>? _tests;
        public static List<Student>? _students;
        public static bool flag = true;

        private readonly OptikArayuzDbContext _context;
        //Componentlerin Veritabanı Stun sayıları
        public enum Columns
        {
            Logo = 3, Number = 6, Student = 2, Grade = 3, Choice = 5, Text = 3, Test = 4
        };

        public ComponentsPartial(OptikArayuzDbContext context)
        {
            //Statik olarak her sayfada aynı componentler kullanılıyor. Componentlerin default değerleri atanıyor. Sürükle bırak menüsündeki elemanların default değerleri.
            if (flag == true)
            {
                _students = new List<Student> { new Student() { XLength = 125, YLength = 60, } };

                _choices = new List<Choice> { new Choice() { ChoiceCount = 2, XLength = 102, YLength = 40, Label = "Kitap türü", Choices = "A-B" } };

                _logos = new List<Logo> { new Logo() { XLength = 102, YLength = 42, ImagePath = "SauLogo.png" } };

                _numbers = new List<Optik_Arayuz_UI.Models.Number> { new Optik_Arayuz_UI.Models.Number() { XLength = 184, YLength = 237, Length = 10, Label = "Ogr", Columns = "0", Values = "" } };

                _grades = new List<Grade> { new Grade() { XLength = 399, YLength = 213, QuestionCount = 10 } };

                _texts = new List<Text> { new Text() { TextContent= "sa",FontSize = 16,FontType = "Calibri"}};

                _tests = new List<Test> { new Test() { XLength = 120, YLength = 100, QuestionCount = 10, BreakPoint=10} };

                flag = false;
            }


            _context = context;

        }

        public IActionResult Logo(string value)
        {
            int n = 0;
            //JS'den gelen value değeri okunuyor. Value yok ise yeni oluşturulur ve default değerler gönderilir. Valuede sadece int değer var ise index değeri olarak atanır ve özellikleri döndürülür. Valuede input değerleri var ise yeni component oluşturulur ve değerleri atanır.
            if (value != null)
            {
                var did = value.Split("/");
                if (did.Length == 1)
                {
                    n= Convert.ToInt32(did[0]);
                }
                else
                {
                    n = Convert.ToInt32(did[3].Substring(did[3].Length - 1));
                    _logos[n].XLength = Convert.ToDouble(did[0]);
                    _logos[n].YLength = Convert.ToDouble(did[1]);
                    _logos[n].ImagePath = did[2];
                }
            }
            else
            {
                _logos.Add(new Logo()
                {
                    XLength = _logos[0].XLength,
                    YLength = _logos[0].YLength,
                    ImagePath = _logos[0].ImagePath,
                });
            }
            //Component Değerleri view'e gönderiliyor.
            ViewData["src"] = _logos[n].ImagePath;
            ViewData["x"] = _logos[n].XLength;
            ViewData["y"] = _logos[n].YLength;
            return PartialView();
        }
        public IActionResult Number(string value)
        {
            //JS'den gelen value değeri okunuyor. Value yok ise yeni oluşturulur ve default değerler gönderilir. Valuede sadece int değer var ise index değeri olarak atanır ve özellikleri döndürülür. Valuede input değerleri var ise yeni component oluşturulur ve değerleri atanır.
            int n = 0;

            if (value != null)
            {
                var did = value.Split("/");
                if (did.Length == 1)
                {
                    n = Convert.ToInt32(did[0]);
                }
                else
                {
                    n = Convert.ToInt32(did[6].Substring(did[6].Length - 1));

                    _numbers[n].XLength = Convert.ToDouble(did[0]);
                    _numbers[n].YLength = Convert.ToDouble(did[1]);
                    _numbers[n].Length = Convert.ToInt32(did[2]);
                    _numbers[n].Label = did[3];
                    _numbers[n].Columns = did[4];
                    _numbers[n].Values = did[5];
                }
            }
            else {
                _numbers.Add(new Optik_Arayuz_UI.Models.Number()
                {
                    XLength = _numbers[0].XLength,
                    YLength = _numbers[0].YLength,
                    Length = _numbers[0].Length,
                    Label = _numbers[0].Label,
                    Columns = _numbers[0].Columns,
                    Values = _numbers[0].Values
                });
            }
            //Component Değerleri view'e gönderiliyor.

            ViewData["x"] = _numbers[n].XLength;
            ViewData["y"] = _numbers[n].YLength;
            ViewData["Length"] = _numbers[n].Length;
            ViewData["Label"] = _numbers[n].Label;
            ViewData["Columns"] = _numbers[n].Columns;
            ViewData["Values"] = _numbers[n].Values;

            return PartialView();
        }
        public IActionResult Student(string value)
        {
            //JS'den gelen value değeri okunuyor. Value yok ise yeni oluşturulur ve default değerler gönderilir. Valuede sadece int değer var ise index değeri olarak atanır ve özellikleri döndürülür. Valuede input değerleri var ise yeni component oluşturulur ve değerleri atanır.

            int n = 0;
            if (value != null)
            {
                var did = value.Split("/");
                if (did.Length == 1)
                {
                    n = Convert.ToInt32(did[0]);
                }
                else
                {
                    n = Convert.ToInt32(did[2].Substring(did[2].Length - 1));

                    _students[n].XLength = Convert.ToDouble(did[0]);
                    _students[n].YLength = Convert.ToDouble(did[1]);
                }
            }
            else {
                _students.Add(new Student() { 
                    XLength = _students[0].XLength,
                    YLength = _students[0].YLength,
                });
            }
            //Component Değerleri view'e gönderiliyor.

            ViewData["x"] = _students[n].XLength;
            ViewData["y"] = _students[n].YLength;

            return PartialView();
        }
        public IActionResult Grade(string value)
        {
            //JS'den gelen value değeri okunuyor. Value yok ise yeni oluşturulur ve default değerler gönderilir. Valuede sadece int değer var ise index değeri olarak atanır ve özellikleri döndürülür. Valuede input değerleri var ise yeni component oluşturulur ve değerleri atanır.

            int n = 0;

            if (value != null)
            {
                var did = value.Split("/");
                if (did.Length == 1)
                {
                    n = Convert.ToInt32(did[0]);
                }
                else
                {
                    n = Convert.ToInt32(did[3].Substring(did[3].Length - 1));

                    _grades[n].XLength = Convert.ToDouble(did[0]);
                    _grades[n].YLength = Convert.ToDouble(did[1]);
                    _grades[n].QuestionCount = Convert.ToInt32(did[2]);
                   
                }
            }
            else
            {
                _grades.Add(new Optik_Arayuz_UI.Models.Grade()
                {
                    XLength = _grades[0].XLength,
                    YLength = _grades[0].YLength,
                    QuestionCount = _grades[0].QuestionCount,
                   
                });
            }
            //Component Değerleri view'e gönderiliyor.

            ViewData["x"] = _grades[n].XLength;
            ViewData["y"] = _grades[n].YLength;
            ViewData["Length"] = _grades[n].QuestionCount;
            

            return PartialView();
        }

        public IActionResult Choice(string value)
        {
            //JS'den gelen value değeri okunuyor. Value yok ise yeni oluşturulur ve default değerler gönderilir. Valuede sadece int değer var ise index değeri olarak atanır ve özellikleri döndürülür. Valuede input değerleri var ise yeni component oluşturulur ve değerleri atanır.

            int n = 0;
            if (value != null)
            {
                var did = value.Split("/");
                if (did.Length == 1)
                {
                    n = Convert.ToInt32(did[0]);
                }
                else
                {
                    n = Convert.ToInt32(did[5].Substring(did[5].Length - 1));
                    _choices[n].XLength = Convert.ToDouble(did[0]);
                    _choices[n].YLength = Convert.ToDouble(did[1]);
                    _choices[n].Label = did[2];
                    _choices[n].ChoiceCount = Convert.ToInt32(did[3]);
                    _choices[n].Choices = did[4];
                }
            }
            else {
                _choices.Add(new Choice()
                {
                    XLength = _choices[0].XLength,
                    YLength = _choices[0].YLength,
                    Label = _choices[0].Label,
                    ChoiceCount = _choices[0].ChoiceCount,
                    Choices = _choices[0].Choices
                });
            }
            //Component Değerleri view'e gönderiliyor.

            ViewData["x"] = _choices[n].XLength;
            ViewData["y"] = _choices[n].YLength;
            ViewData["number"] = _choices[n].ChoiceCount;
            TempData["choices"] = _choices[n].Choices.Split("-");
            ViewData["label"] = _choices[n].Label;

            return PartialView();
        }

        public IActionResult Text(string value)
        {
            //JS'den gelen value değeri okunuyor. Value yok ise yeni oluşturulur ve default değerler gönderilir. Valuede sadece int değer var ise index değeri olarak atanır ve özellikleri döndürülür. Valuede input değerleri var ise yeni component oluşturulur ve değerleri atanır.

            int n = 0;
            if (value != null)
            {
                var did = value.Split("/");
                if (did.Length == 1)
                {
                    n = Convert.ToInt32(did[0]);
                }
                else
                {
                    n = Convert.ToInt32(did[3].Substring(did[3].Length - 1));
                    _texts[n].TextContent = did[0];
                    _texts[n].FontSize = Convert.ToInt32(did[1]);
                    _texts[n].FontType = did[2];
                }
            }
            else {
                _texts.Add(new Text()
                {
                    TextContent = _texts[0].TextContent,
                    FontSize = _texts[0].FontSize,
                    FontType = _texts[0].FontType
                });
            }
            //Component Değerleri view'e gönderiliyor.

            ViewData["content"] = _texts[n].TextContent;
            ViewData["Size"] = _texts[n].FontSize;
            ViewData["FontType"] = _texts[n].FontType;

            return PartialView();
        }
        public IActionResult Test(string value)
        {
            //JS'den gelen value değeri okunuyor. Value yok ise yeni oluşturulur ve default değerler gönderilir. Valuede sadece int değer var ise index değeri olarak atanır ve özellikleri döndürülür. Valuede input değerleri var ise yeni component oluşturulur ve değerleri atanır.

            int n = 0;
            if (value != null)
            {
                var did = value.Split("/");
                if (did.Length == 1)
                {
                    n = Convert.ToInt32(did[0]);
                }
                else
                {
                    n = Convert.ToInt32(did[4].Substring(did[4].Length - 1));
                    _tests[n].XLength = Convert.ToDouble(did[0]);
                    _tests[n].YLength = Convert.ToDouble(did[1]);
                    _tests[n].QuestionCount = Convert.ToInt32(did[2]);
                    _tests[n].BreakPoint = Convert.ToInt32(did[3]);
                }
            }
            else {
                _tests.Add(new Test()
                {
                    XLength = _tests[0].XLength,
                    YLength = _tests[0].YLength,
                    QuestionCount = _tests[0].QuestionCount,
                    BreakPoint = _tests[0].BreakPoint,
                });
            }
            //Component Değerleri view'e gönderiliyor.

            ViewData["x"] = _tests[n].XLength;
            ViewData["y"] = _tests[n].YLength;
            ViewData["QuestionCount"] = _tests[n].QuestionCount;
            ViewData["BreakPoint"] = _tests[n].BreakPoint;
            return PartialView();
        }
        public IActionResult Inputs()
        {
            //Viewdeki inputların değerlerin viewe gönderen fonksiyon.


            //Component Adı ve Index numarası path yoluyla gönderilir.
            string Forum = Request.Path.Value;
            var temp = Forum.Split("/");
            int j = 0;
            string componentName = temp[temp.Length - 1];

            //Component name'i bulunur. Örnek Choice2
            var index = int.TryParse(componentName.Substring((componentName.Length - 1)), out int n);
            if (index != false)
            {
                j = Convert.ToInt32(componentName.Substring(componentName.Length - 1));
                componentName = componentName.Substring(0, (componentName.Length - 1));
            }
            //Örnek : componentName = Choice , j = 2
            //İnputların labelları ve değerleri atanır viewe gönderilir.
            switch (componentName)
            {
                case "Choice":
                    TempData["labels"] = new string[] { "Width", "Height", "Label", "ChoiceCount", "Choices" };
                    TempData["values"] = new string[] { _choices[j].XLength.ToString(), _choices[j].YLength.ToString(), _choices[j].Label, _choices[j].ChoiceCount.ToString(), _choices[j].Choices };

                    break;
                case "Logo":
                    TempData["labels"] = new string[] { "Width", "Height", "ImagePath" };
                    TempData["values"] = new string[] { _logos[j].XLength.ToString(), _logos[j].YLength.ToString(), _logos[j].ImagePath };

                    break;
                case "Number":
                    TempData["labels"] = new string[] { "Width", "Height", "Lenght", "Label","Columns","Values"};
                    TempData["values"] = new string[] { _numbers[j].XLength.ToString(), _numbers[j].YLength.ToString(), _numbers[j].Length.ToString(), _numbers[j].Label, _numbers[j].Columns, _numbers[j].Values };

                    break;
                case "Student":
                    TempData["labels"] = new string[] { "Width", "Height" };
                    TempData["values"] = new string[] { _students[j].XLength.ToString(), _students[j].YLength.ToString() };

                    break;
                case "Grade":
                    TempData["labels"] = new string[] { "Width", "Height","Question Count"};
                    TempData["values"] = new string[] { _grades[j].XLength.ToString(), _grades[j].YLength.ToString() , _grades[j].QuestionCount.ToString() };
                    break;
                case "Text":
                    TempData["labels"] = new string[] { "Content", "FontSize", "FontType" };
                    TempData["values"] = new string[] { _texts[j].TextContent, _texts[j].FontSize.ToString(), _texts[j].FontType };
                    break;
                case "Test":
                    TempData["labels"] = new string[] { "Width", "Height", "QuestionCount", "BreakPoint" };
                    TempData["values"] = new string[] { _tests[j].XLength.ToString(), _tests[j].YLength.ToString(), _tests[j].QuestionCount.ToString(), _tests[j].BreakPoint.ToString() };

                    break;
                default:
                    break;

            }

            //Sütun sayısı bulunur viewe gönderilir.
            int columnNumber = (int)Enum.Parse(typeof(Columns), componentName);

            ViewData["columnNumber"] = columnNumber;
            return PartialView();
        }
        
    }
}
