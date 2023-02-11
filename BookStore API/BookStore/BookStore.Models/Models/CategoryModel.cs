using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookStore.Models.Models;
using BookStore.Models.ViewModels;
using System.ComponentModel.DataAnnotations;

namespace BookStore.Models.Models
{
    public class CategoryModel
    {
        public CategoryModel() { }

        public CategoryModel(Category category)
        {
            Id = category.Id;
            Name = category.Name;
        }

        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

    }
    
}
