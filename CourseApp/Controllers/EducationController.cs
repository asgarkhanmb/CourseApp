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
using System.Drawing;
using Microsoft.EntityFrameworkCore.Metadata.Conventions;

namespace CourseApp.Controllers
{

    public class EducationController
    {
        private readonly IEducationService _educationService;
        private readonly IGroupService _groupService;

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
                Console.WriteLine("Id:" + item.Id  + "Education:" + item.Name + " Color:" + item.Color + " CreatedDate:" + item.CreatedDate);
            }

        }
        public async Task GetAllWithGroupAsync()
        {
            try
            {
                var educations = await _educationService.GetEducationWithGroupsAsync();


                foreach (var item in educations)
                {
                    string result = item.Education + ":" + string.Join(",", item.Groups);
                    Console.WriteLine(result);
                }
            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.Message);
            }
            

        }
        public async Task CreateAsync()
        {
            try
            {
            Education: Console.WriteLine("Create Education");
                string name = Console.ReadLine();
                var data = await _educationService.GetByNameAsync(name);
                if (string.IsNullOrWhiteSpace(name))
                {
                    ConsoleExtension.WriteConsole(ConsoleColor.Red, "Education name can't be eempty:");
                    goto Education;
                }
                else if (!name.Any(char.IsLetter))
                {
                    ConsoleColor.Red.WriteConsole(ResponseMesagges.IncorrectMessage);
                    goto Education;
                }
                if (data is not null)
                {
                    ConsoleColor.Red.WriteConsole(ResponseMesagges.ExistMessage + ResponseMesagges.EnterAgainMessage);
                    goto Education;
                }
            Color: Console.WriteLine("Create Education color");
                string color = Console.ReadLine();
                if (string.IsNullOrWhiteSpace(color))
                {
                    ConsoleExtension.WriteConsole(ConsoleColor.Red, "Color name can't be eempty:");
                    goto Color;
                }
                else if (!color.Any(char.IsLetter))
                {
                    ConsoleColor.Red.WriteConsole(ResponseMesagges.IncorrectMessage);
                    goto Color;
                }
                DateTime dateTime = DateTime.Now;

                await _educationService.CreateAsync(new Education { Name = name.Trim().ToLower(), Color = color.Trim().ToLower(), CreatedDate = dateTime });

                ConsoleColor.Green.WriteConsole(ResponseMesagges.SuccsessMessage);
            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.Message);
            }
      
        }

        public async Task DeleteAsync()
        {
            try
            {
                var data = await _educationService.GetAllAsync();
                foreach (var item in data)
                {
                    Console.WriteLine("Id:" + item.Id + " Name:" + item.Name + " CreatedDate:" + item.CreatedDate);
                }

            Id: Console.WriteLine("Select to id:");
                string idStr = Console.ReadLine();
                if (string.IsNullOrWhiteSpace(idStr))
                {
                    ConsoleExtension.WriteConsole(ConsoleColor.Red, "Id can't be eempty:");
                    goto Id;
                }
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
            catch (Exception ex)
            {

                Console.WriteLine(ex.Message);
            }
            

        }
        public async Task GetByIdAsync()

        {
            try
            {
            IdStr: Console.WriteLine("Add to Id");
                string idStr = Console.ReadLine();
                if (string.IsNullOrWhiteSpace(idStr))
                {
                    ConsoleExtension.WriteConsole(ConsoleColor.Red, "Id can't be eempty:");
                    goto IdStr;
                }
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
                    goto IdStr;
                }

            }
            catch (Exception ex)
            {
                ConsoleColor.Red.WriteConsole(ResponseMesagges.DataNotFound);
                //Console.WriteLine(ex.Message);
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
            try
            {
            Search: Console.WriteLine("Search text");
                string seacrhText = Console.ReadLine();
                if (string.IsNullOrWhiteSpace(seacrhText))
                {
                    ConsoleExtension.WriteConsole(ConsoleColor.Red, "Search can't be eempty:");
                    goto Search;
                }
                var data = await _educationService.SearchByNameAsync(seacrhText);
                foreach (var item in data)
                {
                    Console.WriteLine("Education:" + item.Name + " Color:" + item.Color + " CreatedDate:" + item.CreatedDate);
                }
               
            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.Message);
            }
            
        }
        public async Task SortWithCreatedDateAsync()
        {
            try
            {
                ConsoleColor.Blue.WriteConsole(ResponseMesagges.ChooseSort);
                string text = Console.ReadLine();
                var datas = await _educationService.SortWithCreatedDateAsync(text);
                foreach (var data in datas)
                {
                    Console.WriteLine("Name:" + data.Name + " Color:" + data.Color + " CreateDate:" + data.CreatedDate);
                }
            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.Message);
            }
            
        }


    }
}
