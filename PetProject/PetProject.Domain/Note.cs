using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetProject.Domain
{
    public class Note
    {
        public Note(Guid id, string title, string? description, Status status)
        {
            Id = id;
            Title = title;
            Description = description;
            Status = status;
        }

        public Guid Id { get; set; }
        public string Title { get; set; } = "Default Title";
        public string? Description { get; set; } = null;
        public Status Status { get; set; } = Status.ToDo;

    }
}
