using Microsoft.Data.SqlClient;
using System.Reflection;

namespace CL
{
    public class Example
    {
        private static AppDomain? fDomain = null;
        public static void InitAssembly()
        {
            fDomain = AppDomain.CurrentDomain;
            fDomain.AssemblyResolve += CurrentDomain_AssemblyResolve;
        }

        private static Assembly? CurrentDomain_AssemblyResolve(object? sender, ResolveEventArgs args)
        {
            try
            {
                var sLoaded = fDomain.GetAssemblies();
                var sLoad = sLoaded.FirstOrDefault(x => x.FullName == args.Name);
                if (sLoad != null)
                    return sLoad;

                string sPath = new FileInfo(Assembly.GetExecutingAssembly().Location).Directory.FullName;
                string sTempPath = Path.Combine(sPath, args.Name.Substring(0, args.Name.IndexOf(",")) + ".dll");
                if (sTempPath.Trim() != "")
                {
                    if (File.Exists(sTempPath.Trim()))
                    {
                        byte[] sBytes = File.ReadAllBytes(sTempPath);
                        var sAssembly = Assembly.Load(sBytes);
                        return sAssembly;
                    }
                    else
                        return null;
                }
                else
                    return null;
            }
            catch (Exception ex)
            {
                throw new Exception("Error.\r\n" + ex.Message);
            }
        }

        public bool Connect()
        {
    
            try
            {
                SqlConnection sConn = new SqlConnection(
                    "Data Source=DIEGO-LENOVO\\PDVNET;Initial Catalog=NOHALL;Persist Security Info=True;User ID=sa;Password=inter#system;TrustServerCertificate=True;"
                );

                return true;
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
