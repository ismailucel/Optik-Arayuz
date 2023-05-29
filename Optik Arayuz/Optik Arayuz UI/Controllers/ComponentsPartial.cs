using Azure;
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
        public enum Columns
        {
            Logo = 3, Number = 4, Student = 2, Grade = 3, Choice = 5, Text = 3, Test = 4
        };

        public ComponentsPartial(OptikArayuzDbContext context)
        {
            if (flag == true)
            {
                _students = new List<Student>{ new Student(){XLength = 100,YLength = 100,}};

                _choices = new List<Choice> { new Choice(){ChoiceCount = 2,XLength = 102,YLength = 42,Label = "Kitap türü",Choices = "A-B"}};

                _logos = new List<Logo> {new Logo() {XLength = 102,YLength = 42,ImagePath = "googleturtle.png" } };

                _numbers = new List<Optik_Arayuz_UI.Models.Number> {new Optik_Arayuz_UI.Models.Number() {XLength = 184,YLength = 215,Length = 10,Label = "Ogr"}};

                _grades = new List<Grade>();

                _texts = new List<Text> { new Text() { TextContent= "sa",FontSize = 16,FontType = "Calibri"}};

                _tests = new List<Test> { new Test() { XLength = 120, YLength = 100, QuestionCount = 10, BreakPoint=10} };

                flag = false;
            }


            _context = context;

        }

        public IActionResult Logo(string value)
        {
            int n = 0;


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
            ViewData["src"] = _logos[n].ImagePath;
            ViewData["x"] = _logos[n].XLength;
            ViewData["y"] = _logos[n].YLength;
            return PartialView();
        }
        public IActionResult Number(string value)
        {
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

                    _numbers[n].XLength = Convert.ToDouble(did[0]);
                    _numbers[n].YLength = Convert.ToDouble(did[1]);
                    _numbers[n].Length = Convert.ToInt32(did[2]);
                    _numbers[n].Label = did[3];
                }
            }
            else {
                _numbers.Add(new Optik_Arayuz_UI.Models.Number()
                {
                    XLength = _numbers[0].XLength,
                    YLength = _numbers[0].YLength,
                    Length = _numbers[0].Length,
                    Label = _numbers[0].Label
                });
            }

            ViewData["x"] = _numbers[n].XLength;
            ViewData["y"] = _numbers[n].YLength;
            ViewData["Length"] = _numbers[n].Length;
            ViewData["Label"] = _numbers[n].Label;

            return PartialView();
        }
        public IActionResult Student(string value)
        {

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

            ViewData["x"] = _students[n].XLength;
            ViewData["y"] = _students[n].YLength;

            return PartialView();
        }
        public IActionResult Grade(string value)
        {
            return PartialView();
        }

        public IActionResult Choice(string value)
        {
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

            ViewData["x"] = _choices[n].XLength;
            ViewData["y"] = _choices[n].YLength;
            ViewData["number"] = _choices[n].ChoiceCount;
            TempData["choices"] = _choices[n].Choices.Split("-");
            ViewData["label"] = _choices[n].Label;

            return PartialView();
        }

        public IActionResult Text(string value)
        {
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

            ViewData["content"] = _texts[n].TextContent;
            ViewData["Size"] = _texts[n].FontSize;
            ViewData["FontType"] = _texts[n].FontType;

            return PartialView();
        }
        public IActionResult Test(string value)
        {
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

            ViewData["x"] = _tests[n].XLength;
            ViewData["y"] = _tests[n].YLength;
            ViewData["QuestionCount"] = _tests[n].QuestionCount;
            ViewData["BreakPoint"] = _tests[n].BreakPoint;
            return PartialView();
        }
        public IActionResult Inputs()
        {
            string Forum = Request.Path.Value;
            var temp = Forum.Split("/");
            int j = 0;
            string componentName = temp[temp.Length - 1];

            var index = int.TryParse(componentName.Substring((componentName.Length - 1)), out int n);
            if (index != false)
            {
                j = Convert.ToInt32(componentName.Substring(componentName.Length - 1));
                componentName = componentName.Substring(0, (componentName.Length - 1));
            }

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
                    TempData["labels"] = new string[] { "Width", "Height", "Lenght", "Label" };
                    TempData["values"] = new string[] { _numbers[j].XLength.ToString(), _numbers[j].YLength.ToString(), _numbers[j].Length.ToString(), _numbers[j].Label };

                    break;
                case "Student":
                    TempData["labels"] = new string[] { "Width", "Height" };
                    TempData["values"] = new string[] { _students[j].XLength.ToString(), _students[j].YLength.ToString() };

                    break;
                case "Grade":

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

            int columnNumber = (int)Enum.Parse(typeof(Columns), componentName);

            ViewData["columnNumber"] = columnNumber;
            return PartialView();
        }
        public string SendDatabase(string value)
        {
            Console.WriteLine(value);
            return "true";
        }
    }
}
