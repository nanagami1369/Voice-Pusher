using System;
using System.IO;
using System.Threading.Tasks;
using CoreLibrary;

namespace JsonRepositoryTest
{
    class Program
    {
        class TestUser
        {
            public TestUser(string name, DateTime birthday)
            {
                Name = name;
                Birthday = birthday;
            }

            public string Name { get; set; }
            public DateTime Birthday { get; set; }
        }
        static async Task Main()
        {
            const string testFileName = "Test.Json";
            FileRepository<TestUser> r = new JsonRepository<TestUser>(testFileName);
            // もし、ファイルが存在していたら削除
            if (File.Exists(r.FullPath))
            {
                File.Delete(r.FullPath);
            }
            // 書き込み テスト
            await r.WriterAsync(new TestUser("中田", new DateTime(2000, 7, 21)));
            // 読み込み テスト
            var readTestUser = await r.ReadAsync();
            Console.WriteLine("test ok");
            Console.WriteLine($"TestUser : {{{readTestUser.Name}}} {{{readTestUser.Birthday:yyyy/MM/dd}}}");
        }
    }
}
