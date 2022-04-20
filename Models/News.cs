//------------------------------------------------------------------------------
// <auto-generated>
//     此代码已从模板生成。
//
//     手动更改此文件可能导致应用程序出现意外的行为。
//     如果重新生成代码，将覆盖对此文件的手动更改。
// </auto-generated>
//------------------------------------------------------------------------------

namespace Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public partial class News
    {
        public int NewsID { get; set; }

        [Required(ErrorMessage = "标题不可以为空")]
        public string Title { get; set; }

        [Required(ErrorMessage = "分类不可以为空")]
        public string NType { get; set; }

        [Required(ErrorMessage = "内容不可以为空")]
        public string Content { get; set; }

        [Required(ErrorMessage = "请上传图片")]
        public string PhotoUrl { get; set; }
        public System.DateTime PushTime { get; set; }
        public int States { get; set; }
    }
}
