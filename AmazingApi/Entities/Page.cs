using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace AmazingApi.Entities
{
    public class Page
    {
        public Guid Id { get; set; }
        public int Number { get; set; }
        public string Content { get; set; }

        [ForeignKey("Book")]
        public Guid BookId { get; set; }
        public Book Book { get; set; }

        public Page(Guid id)
        {
            Id = id;
        }

        public Page(int number, string content)
        {
            Id = Guid.NewGuid();
            Number = number;
            Content = content;
        }

    }
}
