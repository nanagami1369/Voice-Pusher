using System;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace CoreLibrary
{
    public abstract class FileRepository<T> : IRepository<T> where T : class
    {
        public FileRepository(string fileName)
        {
            FileName = fileName;
        }

        public string FileName { get; }

        /// <summary>
        ///     ファイルの書き込みに使う文字コード(UTF-8 BOM無し)
        /// </summary>
        public Encoding Encode { get; } = new UTF8Encoding(false);

        /// <summary>
        ///     アプリケーションの実行ディレクトリ
        /// </summary>
        public string AppFullPath => $@"{AppDomain.CurrentDomain.BaseDirectory}\";

        /// <summary>
        ///     ファイルの置かれているディレクトリー
        /// </summary>
        public string BaseDirctoryPath => Path.GetDirectoryName(FullPath) ??
                                          throw new Exception("パスには絶対にファイルパスが入るので呼び出されないはず");

        public string FullPath => AppFullPath + FileName;

        public abstract Task<T> ReadAsync();
        public abstract Task WriterAsync(T saveObject);
    }
}
