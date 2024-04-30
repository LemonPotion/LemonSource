using System.Text.RegularExpressions;

namespace LeMail.Domain.Validations;
/// <summary>
/// Property's patterns
/// </summary>
public class RegexPatterns
{
    public static readonly Regex Email = new(@"^[\w\.-]+@[a-zA-Z\d\.-]+\.[a-zA-Z]{2,}$");
    
    public static readonly Regex FullName = new(@"^[a-zA-Zа-яА-Я0-9']+$");
}