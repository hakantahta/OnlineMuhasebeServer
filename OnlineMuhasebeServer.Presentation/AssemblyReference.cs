using System.Reflection;

//web api deki controller ı presentation katmanında kullanmamız lazım çünkü presentationta kullanmazsak diğer tüm katmanlar 
//web api ye bağlı olmak ve referans almak zorunda kalavak biz bunu istemiyoruz gevşek bağımlılık istiyoruz ne kadar az bağımlılık o kadariyi.
//controller ı prsentationda kullanabilmemiz için onun assembly sini bu katmana oluşturup program.cs ye vermememiz gerekiyor. 

namespace OnlineMuhasebeServer.Presentation
{
    public  static class AssemblyReference
    {
        public static readonly Assembly Assembly = typeof(Assembly).Assembly;
    }
}
