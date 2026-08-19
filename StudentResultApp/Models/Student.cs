using System.ComponentModel.DataAnnotations;

namespace StudentResultApp.Models;

public class Student
{
    public int ResultID { get; set; }

    [Required, StringLength(20)]
    public string StudentNumber { get; set; } = string.Empty;

    [Required, StringLength(150)]
    public string FullName { get; set; } = string.Empty;

    [Required, StringLength(100)]
    public string Module { get; set; } = string.Empty;

    [Range(typeof(decimal), "0", "100")]
    public decimal Mark { get; set; }

    public string GetResult() => Mark >= 50 ? "Pass" : "Fail";
}
