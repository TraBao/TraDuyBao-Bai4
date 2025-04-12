using Microsoft.AspNetCore.Mvc;

namespace gg.Controllers
{
    public class StudentController1 : Controller
    {
        [Route ("HomeStudent")]
        [Route("Student")]
        [Route("Student/ListAll")]
        [Route("Liet-ke-danh-sach-sinh-vien")]
        public string ListAll()
        {
            return "Liệt kê danh sách sinh viên";
        }
        public ContentResult Index() 
        {
            return new ContentResult
            {
                Content = "Welcome to student page ",
                ContentType = "Text/plain "
            };
        
        }
        [Route("File/Download-file")]
        public FileResult Indexx() 
        {
            return File("/linq.pdf", "application.pdf");
        }
        [Route("Student/List")]
        public IActionResult ListOnlyStudent()
        {
            if (!Request.Query.ContainsKey("id"))
            {
                return BadRequest("Student ID is not provided");
            }
            int id = Convert.ToInt32(Request.Query["id"]);
            if (id < 1 || id > 1000)
            {
                return NotFound("Student Id not match");
            }
            return Content("Thong tin sinh vien: " + id, "text/html");
        }
        public IActionResult ListOnlyStudent([FromQuery] int? id)
        {
            if (!id.HasValue)
            {
                return BadRequest("Student ID is not provided");
            }

            return Content($"Thong tin sinh vien {id}");
        }
        public IActionResult ListAlll()
        {
            List<Class> ListStudents = new List<Class>()
            {
                new Class{ Id = 1, Name = "Đức Đạt", Age= 19, Gender=true, ImgUrl="https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcQxBWvQ0dDICviaXW6DyFPU4t5IXxoHE83ZGBEyGoDZinHLvIkss&s", Des="Mô tả thông tin sinh viên"},
                new Class{ Id = 2, Name = "Thùy Trâm", Age= 25, Gender=false, ImgUrl="https://clipart-library.com/img/1421105.png", Des="Mô tả thông tin sinh viên"},
                new Class{ Id = 3, Name = "Nhã Phương", Age= 23, Gender=false, ImgUrl="https://clipart-library.com/img/1421105.png", Des="Mô tả thông tin sinh viên"},
                new Class{ Id = 4, Name = "Thanh Viên", Age= 20, Gender=true, ImgUrl="https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcQxBWvQ0dDICviaXW6DyFPU4t5IXxoHE83ZGBEyGoDZinHLvIkss&s", Des = "Mô tả thông tin sinh viên" },
                new Class{ Id = 5, Name = "Hoàng Việt", Age= 19, Gender=true, ImgUrl="https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcQxBWvQ0dDICviaXW6DyFPU4t5IXxoHE83ZGBEyGoDZinHLvIkss&s", Des="Mô tả thông tin sinh viên"}
            };
            return View(ListStudents);
        }

        public string ListOnlyOne()
        {
            return "Liệt kê một sinh viên có id cụ thể";
        }

        public string EditStudent()
        {
            return "Chỉnh sửa thông tin một sinh viên có id cụ thể";
        }

        public string AddStudent()
        {
            return "Thêm thông tin một sinh viên ";
        }

        public string DelStudent()
        {
            return "Xóa thông tin một sinh viên";
        }
    }
}
