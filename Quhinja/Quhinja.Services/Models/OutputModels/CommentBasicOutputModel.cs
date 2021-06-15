using System;
using System.Collections.Generic;
using System.Text;

namespace Quhinja.Services.Models.OutputModels
{
    public class CommentBasicOutputModel
    {
        public int DishId { get; set; }

        public int UserId { get; set; }

        public string com { get; set; }
        public DateTime DateOfComment { get; set; }
    }
}
