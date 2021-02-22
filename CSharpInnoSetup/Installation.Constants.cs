
using CodingMuscles.CSharpInnoSetup.Converter;
using CodingMuscles.CSharpInnoSetup.Script.Constructs.Code.Library;
using CodingMuscles.CSharpInnoSetup.Script.Constructs.Collection;
using System;
using System.IO;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;

namespace CodingMuscles.CSharpInnoSetup
{
    public partial class Installation
    {
        /// <summary>
        /// Initialized during a period when methods referenced by constants
        /// need to be tracked.
        /// </summary>
        [ThreadStatic]
        private static Action<MethodInfo> _constantReferencedMethod;

        /// <summary>
        /// The application directory, which the user selects on the Select Destination Location page of the wizard.
        /// </summary>
        protected static string __app = "{app}";

        /// <summary>
        /// The system's Windows directory.
        /// </summary>
        protected static string __win = "{win}";

        /// <summary>
        /// The system's System32 directory.
        /// </summary>
        protected static string __sys = "{sys}";

        /// <summary>
        /// On 64-bit Windows, the directory containing 64-bit system files. On 32-bit Windows, the directory containing 
        /// 32-bit system files.
        /// </summary>
        protected static string __sysnative = "{sysnative}";

        /// <summary>
        /// On 64-bit Windows, the system's SysWOW64 directory, typically "C:\WINDOWS\SysWOW64". This is the actual 
        /// directory in which 32-bit system files reside. On 32-bit Windows, 32-bit system files do not reside in a 
        /// separate SysWOW64 directory, so this constant will resolve to the same directory as <see cref="__sys"/> 
        /// if used there.
        /// </summary>
        protected static string __syswow64 = "{syswow64}";

        /// <summary>
        /// The directory in which the Setup files are located.
        /// </summary>
        protected static string __src = "{src}";

        /// <summary>
        /// The path of the system's Program Files directory. {commonpf} is equivalent to {commonpf32} unless the 
        /// install is running in 64-bit install mode, in which case it is equivalent to {commonpf64}.
        /// </summary>
        protected static string __commonpf = "{commonpf}";

        /// <summary>
        /// The path of the system's 32-bit Program Files directory, typically "C:\Program Files" on 32-bit Windows 
        /// and "C:\Program Files (x86)" on 64-bit Windows.
        /// </summary>
        protected static string __commonpf32 = "{commonpf32}";

        /// <summary>
        /// The path of the system's 64-bit Program Files directory, typically "C:\Program Files". An exception will 
        /// be raised if an attempt is made to expand this constant on 32-bit Windows.
        /// </summary>
        protected static string __commonpf64 = "{commonpf64}";

        /// <summary>
        /// The path of the system's Common Files directory. It's equivalent to <see cref="__commoncf32"/>
        /// unless the install is running in 64-bit install mode, in which case it is equivalent to 
        /// <see cref="__commoncf64"/>.
        /// </summary>
        protected static string __commoncf = "{commoncf}";

        /// <summary>
        /// The path of the system's 32-bit Common Files directory, typically "C:\Program Files\Common Files" 
        /// on 32-bit Windows and "C:\Program Files (x86)\Common Files" on 64-bit Windows.
        /// </summary>
        protected static string __commoncf32 = "{commoncf32}";

        /// <summary>
        /// The path of the system's 64-bit Common Files directory, typically "C:\Program Files\Common Files". 
        /// An exception will be raised if an attempt is made to expand this constant on 32-bit Windows.
        /// </summary>
        protected static string __commoncf64 = "{commoncf64}";

        /// <summary>
        /// Temporary directory used by Setup or Uninstall.This is not the value of the user's TEMP environment variable. 
        /// It is a subdirectory of the user's temporary directory which is created by Setup or Uninstall at startup
        /// (with a name like "C:\WINDOWS\TEMP\IS-xxxxx.tmp"). All files and subdirectories in this directory are 
        /// deleted when Setup or Uninstall exits. During Setup, this is primarily useful for extracting files that are 
        /// to be executed in the[Run] section but aren't needed after the installation.
        /// </summary>
        protected static string __tmp = "{tmp}";

        /// <summary>
        /// Fonts directory.  Normally named "Fonts" under the Windows directory.
        /// </summary>
        protected static string __commonfonts = "{commonfonts}";

        /// <summary>
        /// This is equivalent to <see cref="__commoncf"/>\Microsoft Shared\DAO.
        /// </summary>
        protected static string __dao = "{dao}";

        /// <summary>
        /// NET Framework version 1.1 install root directory.
        /// </summary>
        protected static string __dotnet11 = "{dotnet11}";

        /// <summary>
        /// .NET Framework version 2.0-3.5 install root directory.
        /// </summary>
        /// <remarks>
        /// Equivalent to <see cref="__dotnet2032"/> unless the install is running in 64-bit install mode, in which case 
        /// it is equivalent to  <see cref="__dotnet2064"/>.
        /// </remarks>
        protected static string __dotnet20 = "{dotnet20}";

        /// <summary>
        /// NET Framework version 2.0-3.5 install root directory.
        /// </summary>
        protected static string __dotnet2032 = "{dotnet2032}";

        /// <summary>
        /// 64-bit.NET Framework version 2.0-3.5 install root directory.
        /// </summary>
        protected static string __dotnet2064 = "{dotnet2064}";

        /// <summary>
        /// .NET Framework version 4.0 and later install root directory. Equivalent to <see cref="__dotnet4032"/>
        /// unless the install is running in 64-bit install mode, in which case it is equivalent to 
        /// <see cref="__dotnet4064"/>.
        /// </summary>
        protected static string __dotnet40 = "{dotnet40}";

        /// <summary>
        /// 32-bit .NET Framework version 4.0 and later install root directory.
        /// </summary>
        protected static string __dotnet4032 = "{dotnet4032}";

        /// <summary>
        /// 64-bit .NET Framework version 4.0 and later install root directory.
        /// </summary>
        protected static string __dotnet4064 = "{dotnet4064}";

        /// <summary>
        /// The path to the Start Menu folder, as selected by the user on Setup's Select Start Menu Folder wizard page. 
        /// This folder is created in the All Users profile unless the installation is running in non administrative
        /// install mode, in which case it is created in the current user's profile.
        /// </summary>
        protected static string __group = "{group}";

        /// <summary>
        /// The path to the local(nonroaming) Application Data folder.
        /// </summary>
        protected static string __localappdata = "{localappdata}";

        /// <summary>
        /// The path to the Application Data folder.
        /// </summary>
        protected static string __userappdata = "{userappdata}";

        /// <summary>
        /// The path to the Application Data folder.
        /// </summary>
        protected static string __commonappdata = "{commonappdata}";

        /// <summary>
        /// The path to the current user's Common Files directory. Only supported by Windows 7 and later 
        /// if used on previous Windows versions, it will translate to the same directory as 
        /// <see cref="__localappdata"/>\Programs\Common.
        /// </summary>
        protected static string __usercf = "{usercf}";

        /// <summary>
        /// The path to the desktop folder.
        /// </summary>
        protected static string __userdesktop = "{userdesktop}";

        /// <summary>
        /// The path to the desktop folder.
        /// </summary>
        protected static string __commondesktop = "{commondesktop}";

        /// <summary>
        /// The path to the My Documents folder.
        /// </summary>
        protected static string __userdocs = "{userdocs}";

        /// <summary>
        /// The path to the My Documents folder.
        /// </summary>
        protected static string __commondocs = "{commondocs}";

        /// <summary>
        /// The path to the current user's Favorites folder. (There is no common Favorites folder.)
        /// </summary>
        protected static string __userfavorites = "{userfavorites}";

        /// <summary>
        /// The path to the current user's Fonts folder. Supported only in Windows 10 Version 1803 and later. 
        /// Same directory as <see cref="__localappdata"/>\Microsoft\Windows\Fonts.
        /// </summary>
        protected static string __userfonts = "{userfonts}";

        /// <summary>
        /// The path to the current user's Program Files directory. Supported only in Windows 7 and later; 
        /// if used on previous Windows versions, it will translate to the same directory as 
        /// <see cref="__localappdata"/>\Programs.
        /// </summary>
        protected static string __userpf = "{userpf}";

        /// <summary>
        /// The path to the Programs folder on the Start Menu.
        /// </summary>
        protected static string __userprograms = "{userprograms}";

        /// <summary>
        /// The path to the Programs folder on the Start Menu.
        /// </summary>
        protected static string __commonprograms = "{commonprograms}";

        /// <summary>
        /// The path to the current user's Saved Games directory.
        /// </summary>
        protected static string __usersavedgames = "{usersavedgames}";

        /// <summary>
        /// The path to the current user's Send To folder. (There is no common Send To folder.)
        /// </summary>
        protected static string __usersendto = "{usersendto}";

        /// <summary>
        /// The path to the top level of the Start Menu.
        /// </summary>
        protected static string __userstartmenu = "{userstartmenu}";

        /// <summary>
        /// The path to the top level of the Start Menu.
        /// </summary>
        protected static string __commonstartmenu = "{commonstartmenu}";

        /// <summary>
        /// The path to the Startup folder on the Start Menu.
        /// </summary>
        protected static string __userstartup = "{userstartup}";

        /// <summary>
        /// The path to the Startup folder on the Start Menu.
        /// </summary>
        protected static string __commonstartup = "{commonstartup}";

        /// <summary>
        /// The path to the Templates folder.
        /// </summary>
        protected static string __usertemplates = "{usertemplates}";

        /// <summary>
        /// The path to the Templates folder.
        /// </summary>
        protected static string __commontemplates = "{commontemplates}";

        /// <summary>
        /// Maps to <see cref="__commonappdata"/> in administrative install mode, 
        /// or <see cref="__userappdata"/> in non-administrative install mode
        /// </summary>
        protected static string __autoappdata = "{autoappdata}";

        /// <summary>
        /// Maps to <see cref="__commoncf"/> in administrative install mode, 
        /// or <see cref="__usercf"/> in non-administrative install mode
        /// </summary>
        protected static string __autocf = "{autocf}";

        /// <summary>
        /// Maps to <see cref="__commoncf32"/> in administrative install mode, 
        /// or <see cref="__usercf"/> in non-administrative install mode
        /// </summary>
        protected static string __autocf32 = "{autocf32}";

        /// <summary>
        /// Maps to <see cref="__commoncf64"/> in administrative install mode, 
        /// or <see cref="__usercf"/> in non-administrative install mode
        /// </summary>
        protected static string __autocf64 = "{autocf64}";

        /// <summary>
        /// Maps to <see cref="__commondesktop"/> in administrative install mode, 
        /// or <see cref="__userdesktop"/> in non-administrative install mode
        /// </summary>
        protected static string __autodesktop = "{autodesktop}";

        /// <summary>
        /// Maps to <see cref="__commondocs"/> in administrative install mode, 
        /// or <see cref="__userdocs"/> in non-administrative install mode
        /// </summary>
        protected static string __autodocs = "{autodocs}";

        /// <summary>
        /// Maps to <see cref="__commonfonts"/> in administrative install mode, 
        /// or <see cref="__userfonts"/> in non-administrative install mode
        /// </summary>
        protected static string __autofonts = "{autofonts}";//    

        /// <summary>
        /// Maps to <see cref="__commonpf"/> in administrative install mode, 
        /// or <see cref="__userpf"/> in non-administrative install mode
        /// </summary>
        protected static string __autopf = "{autopf}";

        /// <summary>
        /// Maps to <see cref="__commonpf32"/> in administrative install mode, 
        /// or <see cref="__userpf"/> in non-administrative install mode
        /// </summary>
        protected static string __autopf32 = "{autopf32}";

        /// <summary>
        /// Maps to <see cref="__commonpf64"/> in administrative install mode, 
        /// or <see cref="__userpf"/> in non-administrative install mode
        /// </summary>
        protected static string __autopf64 = "{autopf64}";

        /// <summary>
        /// Maps to <see cref="__commonprograms"/> in administrative install mode, 
        /// or <see cref="__userprograms"/> in non-administrative install mode
        /// </summary>
        protected static string __autoprograms = "{autoprograms}";

        /// <summary>
        /// Maps to <see cref="__commonstartmenu"/> in administrative install mode, 
        /// or <see cref="__userstartmenu"/> in non-administrative install mode
        /// </summary>
        protected static string __autostartmenu = "{autostartmenu}";

        /// <summary>
        /// Maps to <see cref="__commonstartup"/> in administrative install mode, 
        /// or <see cref="__userstartup"/> in non-administrative install mode
        /// </summary>
        protected static string __autostartup = "{autostartup}";

        /// <summary>
        /// Maps to <see cref="__commontemplates"/> in administrative install mode, 
        /// or <see cref="__usertemplates"/> in non-administrative install mode
        /// </summary>
        protected static string __autotemplates = "{autotemplates}";

        /// <summary>
        /// A backslash \ character
        /// </summary>
        protected static string __slash = "{\\}";


        /// <summary>
        /// Embeds the value of an environment variable.
        /// </summary>
        /// <param name="name">The name of the environment variable to use</param>
        /// <returns></returns>
        protected static string __env(string name)
        {
            return __env(name, null);
        }

        /// <summary>
        /// Embeds the value of an environment variable.
        /// </summary>
        /// <param name="name">The name of the environment variable to use</param>
        /// <param name="defaultValue">The string to embed if the specified variable does not exist on the user's 
        /// system.</param>
        /// <returns></returns>
        protected static string __env(string name, string defaultValue)
        {
            string envFormat;

            if (defaultValue == null)
            {
                envFormat = "{0}";
            }
            else
            {
                envFormat = "{0}|{1}";
                defaultValue = Escape(defaultValue);
            }

            return $"{{%{string.Format(envFormat, name, defaultValue)}}}";
        }

        /// <summary>
        /// The full pathname of the system's standard command interpreter, Windows\System32\cmd.exe. Note that the 
        /// COMSPEC environment variable is not used when expanding this constant.
        /// </summary>
        protected static string __cmd = "{cmd}";

        /// <summary>
        /// The name of the computer the Setup or Uninstall program is running on (as returned by the Windows 
        /// GetComputerName function).
        /// </summary>
        protected static string __computername = "{computername}";

        /// <summary>
        /// Extracts and returns the drive letter and colon (e.g. "C:") from the specified path.
        /// </summary>
        /// <param name="path">The path from which to extract the drive.</param>
        /// <returns>The drive letter, or In the case of a UNC path, it returns the server and share name 
        /// (e.g. "\\SERVER\SHARE").</returns>
        protected static string __drive(string path)
        {
            return $"{{drive:{Escape(path)}}}";
        }

        /// <summary>
        /// The name of the folder the user selected on Setup's Select Start Menu Folder wizard page. This 
        /// differs from <see cref="__group"/> in that it is only the name; it does not include a path.
        /// </summary>
        protected static string __groupname = "{groupname}";

        /// <summary>
        /// Translates to the window handle of the Setup program's background window.
        /// </summary>
        protected static string __hwnd = "{hwnd}";

        /// <summary>
        /// Translates to the window handle of the Setup wizard window.  This handle is set to '0' if the window 
        /// handle isn't available at the time the translation is done.
        /// </summary>
        protected static string __wizardhwnd = "{wizardhwnd}";

        /// <summary>
        /// Embeds a value from an.INI file.
        /// </summary>
        /// <param name="fileName">The name of the.INI file to read from</param>
        /// <param name="section">The name of the section to read from</param>
        /// <param name="key">The name of the key to read</param>
        /// <returns>The extracted ini value, or the default</returns>
        protected static string __ini(FileInfo fileName, string section, string key)
        {
            return __ini(fileName, section, key, null);
        }

        /// <summary>
        /// Embeds a value from an.INI file.
        /// </summary>
        /// <param name="fileName">The name of the.INI file to read from</param>
        /// <param name="section">The name of the section to read from</param>
        /// <param name="key">The name of the key to read</param>
        /// <param name="defaultValue">The string to embed if the specified key does not exist</param>
        /// <returns>The extracted ini value, or the default</returns>
        protected static string __ini(FileInfo fileName, string section, string key, string defaultValue)
        {
            return __ini(fileName.ToString(), section, key, defaultValue);
        }

        /// <summary>
        /// Embeds a value from an.INI file.
        /// </summary>
        /// <param name="fileName">The name of the.INI file to read from</param>
        /// <param name="section">The name of the section to read from</param>
        /// <param name="key">The name of the key to read</param>
        /// <returns>The extracted ini value, or the default</returns>
        protected static string __ini(string fileName, string section, string key)
        {
            return __ini(fileName, section, key, null);
        }

        /// <summary>
        /// Embeds a value from an.INI file.
        /// </summary>
        /// <param name="fileName">The name of the.INI file to read from</param>
        /// <param name="section">The name of the section to read from</param>
        /// <param name="key">The name of the key to read</param>
        /// <param name="defaultValue">The string to embed if the specified key does not exist</param>
        /// <returns>The extracted ini value, or the default</returns>
        protected static string __ini(string fileName, string section, string key, string defaultValue)
        {
            var fmt = defaultValue == null ? "{0}" : "{0}|{1}";
            var parts = string.Join(",", new[] { fileName, section, key }.Select(v => Escape(v)));

            return $"{{ini:{string.Format(fmt, parts, Escape(defaultValue))}}}";
        }

        /// <summary>
        /// The internal name of the selected language.
        /// </summary>
        protected static string __language = "{language}";

        /// <summary>
        /// Embeds a custom message value based on the active language.
        /// </summary>
        /// <param name="customMessage">The expression that references a custom message</param>
        /// <param name="args">A list of arguments to the message value</param>
        /// <returns>The constant for the custom message</returns>
        protected static string __cm(Expression<Func<Message>> customMessage, params string[] args)
        {
            var messageId = ((PropertyInfo)((MemberExpression)customMessage.Body).Member).Name;
            return $"{{cm:{string.Join(",", new[] { messageId }.Concat(args.Select(Escape)))}}}";
        }

        /// <summary>
        /// Embeds a registry value.
        /// </summary>
        /// <param name="hive">The root key</param>
        /// <param name="subkey">The name of the subkey</param>
        /// <returns>The value of the registry entry</returns>
        protected static string __reg(RegistryHive hive, string subkey)
        {
            return __reg(hive, subkey, null, null);
        }

        /// <summary>
        /// Embeds a registry value.
        /// </summary>
        /// <param name="hive">The root key</param>
        /// <param name="subkey">The name of the subkey</param>
        /// <param name="valueName">The name of the value whose value to read, or
        /// null to read the key's default value</param>
        /// <returns>The value of the registry entry</returns>
        protected static string __reg(RegistryHive hive, string subkey, string valueName)
        {
            return __reg(hive, subkey, valueName, null);
        }

        /// <summary>
        /// Embeds a registry value.
        /// </summary>
        /// <param name="hive">The root key</param>
        /// <param name="subkey">The name of the subkey</param>
        /// <param name="valueName">The name of the value whose value to read, or
        /// null to read the key's default value</param>
        /// <param name="defaultValue">The string to return if the specified registry value does not exist</param>
        /// <returns>The value of the registry entry</returns>
        protected static string __reg(RegistryHive hive, string subkey, string valueName, string defaultValue)
        {
            var constant = $"{{reg:{hive}\\{subkey}";

            if(valueName != null)
            {
                constant += $",{valueName}";
            }    

            if(defaultValue != null)
            {
                constant += $"|{defaultValue}";
            }

            return constant + "}";
        }

        /// <summary>
        /// Resolves to a command line parameter value.
        /// </summary>
        /// <param name="name">The name of the command line parameter</param>
        /// <returns>The value of the command line parameter</returns>
        protected static string __param(string name)
        {
            return __param(name, null);
        }

        /// <summary>
        /// Resolves to a command line parameter value.
        /// </summary>
        /// <param name="name">The name of the command line parameter</param>
        /// <param name="defaultValue">The value to return if the parameter does not exist</param>
        /// <returns>The value of the command line parameter</returns>
        protected static string __param(string name, string defaultValue)
        {
            var fmt = defaultValue == null ? "{0}" : "{0}|{1}";
            return $"{{param:{string.Format(fmt, name, Escape(defaultValue))}}}";
        }

        /// <summary>
        /// The full pathname of the Setup program file
        /// </summary>
        protected static string __srcexe = "{srcexe}";

        /// <summary>
        /// The full pathname of the uninstall program extracted by Setup.  It is only valid if Uninstallable is 
        /// yes (the default setting)
        /// </summary>
        protected static string __uninstallexe = "{uninstallexe}";

        /// <summary>
        /// The name to which Windows is registered
        /// </summary>
        protected static string __sysuserinfoname = "{sysuserinfoname}";

        /// <summary>
        /// The organization to which Windows is registered
        /// </summary>
        protected static string __sysuserinfoorg = "{sysuserinfoorg}";

        /// <summary>
        /// The name the user entered on the User Information wizard page
        /// </summary>
        protected static string __userinfoname = "{userinfoname}";

        /// <summary>
        /// The organization the user entered on the User Information wizard page
        /// </summary>
        protected static string __userinfoorg = "{userinfoorg}";

        /// <summary>
        /// The serial number the user entered on the User Information wizard page
        /// </summary>
        protected static string __userinfoserial = "{userinfoserial}";

        /// <summary>
        /// The name of the user who is running Setup or Uninstall program (as returned by the GetUserName function).
        /// </summary>
        protected static string __username = "{username}";

        /// <summary>
        /// The log file name, or an empty string if logging is not enabled
        /// </summary>
        protected static string __log = "{log}";
        
        /// <summary>
        /// A name of a method to call
        /// </summary>
        protected static string __code(Expression<Action> expression)
        {
            var converter = new DelegateExpressionToStringConverter<Action>(mi => _constantReferencedMethod?.Invoke(mi), "{0}|{1}", false);
            var result = converter.ConvertTo(expression, typeof(string)) as string;
            return $"{{code:{result.Trim('|')}}}";
        }

        /// <summary>
        /// A name of a method to call
        /// </summary>
        protected static string __code(Expression<Func<Func<string, string>>> expression)
        {
            var method = (((expression.Body as UnaryExpression).Operand as MethodCallExpression).Object as ConstantExpression).Value as MethodInfo;
            _constantReferencedMethod?.Invoke(method);
            return $"{{code:{method.Name}}}";
        }

        /// <summary>
        /// A name of a method to call
        /// </summary>
        protected static string __code(Expression<Func<Action<string>>> expression)
        {
            var method = (((expression.Body as UnaryExpression).Operand as MethodCallExpression).Object as ConstantExpression).Value as MethodInfo;
            _constantReferencedMethod?.Invoke(method);
            return $"{{code:{method.Name}}}";
        }

        private static string Escape(string value)
        {
            if(value == null)
            {
                return null;
            }

            return value.Replace("%", "%25").Replace(", ", "%2c").Replace("}", "%7d").Replace("|", "%7c");
        }
    }
}
