using Domain.Models;
using Service.Helpers.Constants;
using Service.Helpers.Exceptions;
using Service.Helpers.Extensions;
using Service.Services.Interfaces;
using Service.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourseApp.Controllers
{

    public class EducationController
    {
        private readonly IEducationService _educationService;
        private readonly GroupService _groupService;

        public EducationController()
        {
            _educationService = new EducationService();
            _groupService = new GroupService();

        }
        public async Task GetAllAsync()
        {
            var data = await _educationService.GetAllAsync();
            foreach (var item in data)
            {
                Console.WriteLine("Education:" + item.Name + " Color:" + item.Color + " CreatedDate:" + item.CreatedDate);
            }

        }
        public async Task GetAllWithGroupAsync()
        {
            var educations = await _educationService.GetEducationWithGroupsAsync();


            foreach (var item in educations)
            {
                string result = item.Education + ":" + string.Join(",", item.Groups);
                Console.WriteLine(result);
            }

        }
        public async Task CreateAsync()
        {
        Education: Console.WriteLine("Create Education");
            string name = Console.ReadLine();
            var data = await _educationService.SearchByNameAsync(name);
            if (data.Count != 0)
            {
                ConsoleColor.Red.WriteConsole(ResponseMesagges.ExistMessage+ResponseMesagges.EnterAgainMessage);
                goto Education;
            }
            Console.WriteLine("Create Education color");
            string color = Console.ReadLine();


            DateTime dateTime = DateTime.Now;


            await _educationService.CreateAsync(new Education { Name = name.Trim().ToLower(), Color = color.Trim().ToLower(), CreatedDate = dateTime });


            ConsoleColor.Green.WriteConsole(ResponseMesagges.SuccsessMessage);
        }

        public async Task DeleteAsync()
        {
            var data = await _educationService.GetAllAsync();
            foreach (var item in data)
            {
                Console.WriteLine("Id:" + item.Id + " Name:" + item.Name + " CreatedDate:" + item.CreatedDate);
            }

        Id: Console.WriteLine("Select to id:");
            string idStr = Console.ReadLine();
            int id;
            bool isCorrectIdFormat = int.TryParse(idStr, out id);
            if (isCorrectIdFormat)
            {
                var response = await _educationService.GetByIdAsync(id);
                _educationService.DeleteAsync(response);
            }
            else
            {
                goto Id;
            }


        }
        public async Task GetByIdAsync()

        {
        Id: Console.WriteLine("Add to Id");
            string idStr = Console.ReadLine();
            int id;
            bool isCorrectIdFormat = int.TryParse(idStr, out id);
            if (isCorrectIdFormat)
            {
                var item = await _educationService.GetByIdAsync(id);
                Console.WriteLine("Education:" + item.Name + " Color:" + item.Color + " CreatedDate:" + item.CreatedDate);
            }
            else
            {
                ConsoleColor.Red.WriteConsole(ResponseMesagges.FormatMessage);
                goto Id;
            }

        }
        public async Task UpdateAsync()
        {
            var datas = await _educationService.GetAllAsync();
            foreach (var item in datas)
            {
                Console.WriteLine("Id:" + item.Id + " Education:" + item.Name + " Color:" + item.Color + " CreatedDate:" + item.CreatedDate);
            }
            bool update = true;
        Id: ConsoleColor.DarkYellow.WriteConsole("Add to Id:");
            string idStr = Console.ReadLine();
            int id;
            bool isCorrectIdFormat = int.TryParse(idStr, out id);
            if (isCorrectIdFormat)
            {
                try
                {
                    var data = _educationService.GetByIdAsync(id);
                    if (data is null)
                    {
                        throw new NotFoundException(ResponseMesagges.DataNotFound);

                    }
                    Console.WriteLine("Enter new Education ");
                    string newEducation = Console.ReadLine();
                    if (!string.IsNullOrWhiteSpace(newEducation))
                    {
                        var response = await _educationService.SearchByNameAsync(newEducation);
                        if (response.Count == 0)
                        {
                            if (data.Result.Name.ToLower().Trim() != newEducation.ToLower().Trim())
                            {
                                data.Result.Name = newEducation;
                                update = false;
                            }
                        }

                    }
                    Console.WriteLine("Enter new color");
                    string newColor = Console.ReadLine();
                    if (!string.IsNullOrWhiteSpace(newColor))
                    {
                        if (data.Result.Color.ToLower().Trim() != newColor.ToLower().Trim())
                        {
                            data.Result.Color = newColor;
                            update = false;
                        }



                    }

                    if (update)
                    {
                        ConsoleColor.DarkRed.WriteConsole("don't change");
                    }
                    else
                    {
                        data.Result.CreatedDate = DateTime.Now;
                        _educationService.UpdateAsync(data.Result);
                        ConsoleColor.Blue.WriteConsole("Data update succesfuly");
                    }

                }
                catch (Exception ex)
                {
                    ConsoleColor.Red.WriteConsole(ex.Message);
                }

            }
            else
            {
                ConsoleColor.Red.WriteConsole(ResponseMesagges.FormatMessage);
                goto Id;
            }
        }

        public async Task SearchByNameAsync()
        {
            Console.WriteLine("Search text");
            string seacrhText = Console.ReadLine();
            var data = await _educationService.SearchByNameAsync(seacrhText);
            foreach (var item in data)
            {
                Console.WriteLine("Education:" + item.Name + " Color:" + item.Color + " CreatedDate:" + item.CreatedDate);
            }
        }
        public async Task SortWithCreatedDateAsync()
        {
            ConsoleColor.Blue.WriteConsole(ResponseMesagges.ChooseSort);
            string text = Console.ReadLine();
            var datas = await _educationService.SortWithCreatedDateAsync(text);
            foreach (var data in datas)
            {
                Console.WriteLine("Name:" + data.Name + " Color:" + data.Color + " CreateDate:" + data.CreatedDate);
            }

        }


    }
}
