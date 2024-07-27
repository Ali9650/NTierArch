using Application.Services.Abstract;
using Core.Entities;
using Core.Messages;
using Data.Contexts;
using Data.Repositories.Concrete;
using Data.UniOfWork.Concrete;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data.Repositories.Concrete;
using Core.Extensions;

namespace Application.Services.Concrete
{
    public class GroupService : IGroupService
    {
        private  readonly UniOfWork _uniOfWork;
        private readonly GroupRepository _groupRepository;

        public GroupService()
        {
            _uniOfWork = new UniOfWork();         
        }    
        
        public void GetAllGroups()
        {
            foreach (var group in _uniOfWork.Groups.GetAll())
                Console.WriteLine($"Id - {group.Id}, Name - {group.Name}");
        }
        public void AddGroup()
        {
        GroupNameInput: Messages.InputMessages("Group name");
            string name = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(name))
            {
                Messages.InvalidInputMeesages("Group Name");
                goto GroupNameInput;
            }
         
            var existGroup = _groupRepository.GetByName(name);

            if (existGroup is not null)
            {
                Messages.AlreadyExistMessage($"Group name - {name}");
                goto GroupNameInput;
            }

        GroupLimitInput: Messages.InputMessages("Group limit");
            string limitInput = Console.ReadLine();
            int limit;
            bool isSucceeded = int.TryParse(limitInput, out limit);
            if (!isSucceeded || limit <= 0)
            {
                Messages.InvalidInputMeesages("Group limit");
                goto GroupLimitInput;
            }


            var group = new Group
            {
                Name = name,
                Limit = limit,
            };
            _uniOfWork.Groups.Add(group);
            try
            {
                _uniOfWork.Commit();
            }
            catch (Exception)
            {
                Messages.ErrorOccuredMessage();
            }
            Messages.SuccessMessages("Group", "added");
        }

        public void UpdateGroup()
        {
        GroupIdInput: GetAllGroups();
            Messages.InputMessages("group id");
            string IdInput = Console.ReadLine();
            int groupId;
            bool issucceeded = int.TryParse(IdInput, out groupId);
            if (!issucceeded)
            {
                Messages.InvalidInputMeesages("group id");
                goto GroupIdInput;
            }
            var existGroup = _uniOfWork.Groups.Get(groupId);
            if (existGroup is null)
            {
                Messages.NotFountMessage("group");
                goto GroupIdInput;
            }
            string Name = existGroup.Name;      
        GroupNameInput: Messages.WantToChangeMessage("name");
            string input = Console.ReadLine();
            issucceeded = char.TryParse(input, out char answer);
            if (!issucceeded || !answer.IsValidChoice())
            {
                Messages.InvalidInputMeesages("answer");
                goto GroupNameInput;
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
                var ExistGroupName = _groupRepository.GetByName(Name);
                if (ExistGroupName is not null)
                {
                    Messages.AlreadyExistMessage("group name");
                    goto GroupNameInput;
                }
            }
            int Limit = existGroup.Limit;
        GroupLimitInput: Messages.WantToChangeMessage("limit");
            input = Console.ReadLine();
            issucceeded = char.TryParse(input, out answer);
            if (!issucceeded || !answer.IsValidChoice())
            {
                Messages.InvalidInputMeesages("answer");
                goto GroupLimitInput;
            }
            if (answer == 'y')
            {
            LimitInput: Messages.InputMessages("limit");
                string newLimitInput = Console.ReadLine();
                issucceeded = int.TryParse(newLimitInput, out Limit);
                if (!issucceeded)
                {
                    Messages.InvalidInputMeesages("limit");
                    goto LimitInput;
                }
            }
        
            existGroup.Name = Name;
            existGroup.Limit = Limit;
           
           _uniOfWork.Groups.Update(existGroup);
            try
            {
           _uniOfWork.Commit();
            }
            catch (Exception)
            {

                Messages.ErrorOccuredMessage();
            }
            Messages.SuccessMessages("group", "updated");

        }

        public  void DeleteGroup()
        {
            GetAllGroups();
        InputGroupId: Messages.InputMessages("Group id");
            string inputId = Console.ReadLine();
            int groupId;
            bool issucceeded = int.TryParse(inputId, out groupId);
            if (!issucceeded)
            {
                Messages.InvalidInputMeesages("Group id");
                goto InputGroupId;
            }
            var group = _groupRepository.Get(groupId);
            if (group is null)
            {
                Messages.NotFountMessage("Group");
                return;
            }

            
            _uniOfWork.Groups.Update(group);
            try
            {
                _uniOfWork.Commit();
            }
            catch (Exception)
            {

                Messages.ErrorOccuredMessage();
            }
            Messages.SuccessMessages("Group", "deleted");
        }

        public  void GetDetailsofGroup()
        {
            GetAllGroups();
        InputGroupId: Messages.InputMessages("Group id");
            string inputId = Console.ReadLine();
            int groupId;
            bool issucceeded = int.TryParse(inputId, out groupId);
            if (!issucceeded)
            {
                Messages.InvalidInputMeesages("Group id");
                goto InputGroupId;
            }
            var group = _groupRepository.GetByIdWithStudents(groupId);
            if (group is null)
            {
                Messages.NotFountMessage("Group");
                return;
            }
            foreach (var student in group.Students)
            {
                Console.WriteLine($"{student.Name}, {student.Surmame}");
            }
        }
    }
}
