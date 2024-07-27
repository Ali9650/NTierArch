using Application.Services.Abstract;
using Core.Entities;
using Core.Extensions;
using Core.Messages;
using Data.Contexts;
using Data.Repositories.Abstract;
using Data.Repositories.Concrete;
using Data.UniOfWork.Concrete;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services.Concrete
{
    public class StudentService : IStudentService
    {
        private  readonly UniOfWork _uniOfWork;
        private readonly StudentRepository _studentRepository;
        private readonly GroupRepository _groupRepository;
        public StudentService()
        {
            _uniOfWork = new UniOfWork();
        }
        
            public  void GetAllStudents()
            {
                foreach (var student in _uniOfWork.Students.GetAll())
                {
                    Console.WriteLine($"id:{student.Id}, Name: {student.Name}, Surname:{student.Surmame}");
                }
            }

            public   void AddStudent()
            {
            StudentNameInput: Messages.InputMessages("Student name");
                string name = Console.ReadLine();

                if (string.IsNullOrWhiteSpace(name))
                {
                    Messages.InvalidInputMeesages("Student name");
                    goto StudentNameInput;
                }

            StudentSurnameInput: Messages.InputMessages("Student surname");
                string surname = Console.ReadLine();
                if (string.IsNullOrWhiteSpace(surname))
                {
                    Messages.InvalidInputMeesages("Student surname");
                    goto StudentSurnameInput;
                }

           

            GroupList: _groupRepository.GetAll();

                Messages.InputMessages("Group id");
                string groupIdInput = Console.ReadLine();
                int id;        
                bool isSucceeded = int.TryParse(groupIdInput, out id);
                if (!isSucceeded)
                {
                    Messages.InvalidInputMeesages("Group id");
                    goto GroupList;
                }

                var group = _uniOfWork.Groups.Get(id);
                if (group is null)
                {
                    Messages.NotFountMessage("Group");
                    goto GroupList;
                }


                Student student = new Student
                {
                    Name = name,
                    Surmame = surname,                   
                    GroupId = group.Id
                };

                _uniOfWork.Students.Add(student);
                try
                {
                    _uniOfWork.Commit();
                }
                catch (Exception ex)
                {
                    Messages.ErrorOccuredMessage();
                }

                Messages.SuccessMessages("Student", "added");

            }

            public  void UpdateStudent()
            {
            StudentIdInput: GetAllStudents();
                Messages.InputMessages("student id");
                string IdInput = Console.ReadLine();
                int studentId;
                bool issucceeded = int.TryParse(IdInput, out studentId);
                if (!issucceeded)
                {
                    Messages.InvalidInputMeesages("student id");
                    goto StudentIdInput;
                }
                var existStudent = _uniOfWork.Students.Get (studentId);
                if (existStudent is null)
                {
                    Messages.NotFountMessage("student");
                    goto StudentIdInput;
                }
                string Name = existStudent.Name;
            StudentNameInput: Messages.WantToChangeMessage("name");
                string input = Console.ReadLine();
                issucceeded = char.TryParse(input, out char answer);
                if (!issucceeded || !answer.IsValidChoice())
                {
                    Messages.InvalidInputMeesages("answer");
                    goto StudentNameInput;
                }
                if (answer == 'y')
                {
                NameInput: Messages.InputMessages("New name");
                    Name = Console.ReadLine();
                    if (string.IsNullOrWhiteSpace(Name))
                    {
                        Messages.InvalidInputMeesages("name");
                        goto NameInput;
                    }
                }
            StudentSurnameInput: Messages.WantToChangeMessage("surname");
                string surnameinput = Console.ReadLine();
                issucceeded = char.TryParse(surnameinput, out char answerr);
                if (!issucceeded || !answerr.IsValidChoice())
                {
                    Messages.InvalidInputMeesages("answerr");
                    goto StudentSurnameInput;
                }
                if (answer == 'y')
                {
                SurnameInput: Messages.InputMessages("New surname");
                    surnameinput = Console.ReadLine();
                    if (string.IsNullOrWhiteSpace(surnameinput))
                    {
                        Messages.InvalidInputMeesages("surname");
                        goto SurnameInput;
                    }
                }
            
                int Groupid = existStudent.GroupId;
                if (_uniOfWork.Groups.GetAll().Count > 1)
                {
                GroupInput: Messages.WantToChangeMessage("group");
                    input = Console.ReadLine();
                    issucceeded = char.TryParse(input, out answer);
                    if (issucceeded || !answer.IsValidChoice())
                    {
                        Messages.InvalidInputMeesages("answer");
                        goto GroupInput;
                    }
                    if (answer == 'y')
                    {
                    Groupid: _groupRepository.GetAll();
                        Messages.InputMessages("group id");
                        string GroupIdInput = Console.ReadLine();
                        issucceeded = int.TryParse(GroupIdInput, out Groupid);
                        if (!issucceeded)
                        {
                            Messages.InvalidInputMeesages("group id");
                            goto GroupInput;
                        }
                        var ExistGroup = _studentRepository.GetByIdWithGroups(Groupid); 
                        if (ExistGroup is null)
                        {
                            Messages.NotFountMessage("id");
                            goto Groupid;
                        }
                    }
                }
                existStudent.Name = Name;
                existStudent.Surmame = surnameinput;
                existStudent.GroupId = Groupid;

                _uniOfWork.Students.Update(existStudent);

                try
                {
                    _uniOfWork.Commit();
                }
                catch (Exception)
                {

                    Messages.ErrorOccuredMessage();
                }
                Messages.SuccessMessages("student", "updated");

            }

            public  void DeleteStudent()
            {
                GetAllStudents();
            InputStudentId: Messages.InputMessages("student id");
                string inputId = Console.ReadLine();
                int studentId;
                bool issucceeded = int.TryParse(inputId, out studentId);
                if (!issucceeded)
                {
                    Messages.InvalidInputMeesages("student id");
                    goto InputStudentId;
                }

                var student = _uniOfWork.Students.Get(studentId);
                if (student is null)
                {
                    Messages.NotFountMessage("student");
                    return;
                }
                _uniOfWork.Students.Update(student);
                try
                {
                    _uniOfWork.Commit();
                }
                catch (Exception)
                {

                    Messages.ErrorOccuredMessage();
                }
                Messages.SuccessMessages("Student", "deleted");
            }

            public  void GetDetailsofStudent()
            {
                GetAllStudents();
            InputStudentId: Messages.InputMessages("Student id");
                string inputId = Console.ReadLine();
                int studentId;
                bool issucceeded = int.TryParse(inputId, out studentId);
                if (!issucceeded)
                {
                    Messages.InvalidInputMeesages("Student id");
                    goto InputStudentId;
                }
                var student = _studentRepository.GetByIdWithGroups(studentId);  

                if (student == null)
                {
                    Messages.NotFountMessage("Student");
                    return;
                }

                Console.WriteLine($"{student.Name}, {student.Surmame}, {student.Group.Name}");


            }

        }
    }

