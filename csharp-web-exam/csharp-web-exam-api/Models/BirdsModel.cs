


using csharp_web_exam_api;
using System.ComponentModel.DataAnnotations;

public class BirdsModel
{
    [Key]
    public int Id { get; set; }
    public string Name { get; set; }
    public string Feeding { get; set; }

    public int TypeId { get; set; }
    public TypeBirdModel TypeBirds { get; set; }
}

