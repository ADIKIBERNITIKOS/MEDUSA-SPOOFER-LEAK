using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Diagnostics;
using System.IO;
using System.Net;
using System.Runtime.Serialization;
using System.Security.Cryptography;
using System.Security.Principal;
using System.Text;

namespace KeyAuth
{
	// Token: 0x02000009 RID: 9
	public class api
	{
		// Token: 0x0600002C RID: 44 RVA: 0x00003348 File Offset: 0x00003348
		public api(string name, string ownerid, string secret, string version)
		{
			if (string.IsNullOrWhiteSpace(name) || string.IsNullOrWhiteSpace(ownerid) || string.IsNullOrWhiteSpace(secret) || string.IsNullOrWhiteSpace(version))
			{
				api.error("Application not setup correctly. Please watch video link found in Program.cs");
				Environment.Exit(0);
			}
			this.name = name;
			this.ownerid = ownerid;
			this.secret = secret;
			this.version = version;
		}

		// Token: 0x0600002D RID: 45 RVA: 0x000033DC File Offset: 0x000033DC
		public void init()
		{
			this.enckey = encryption.sha256(encryption.iv_key());
			string text = encryption.sha256(encryption.iv_key());
			NameValueCollection nameValueCollection = new NameValueCollection();
			nameValueCollection["type"] = encryption.byte_arr_to_str(Encoding.Default.GetBytes("init"));
			nameValueCollection["ver"] = encryption.encrypt(this.version, this.secret, text);
			nameValueCollection["hash"] = api.checksum(Process.GetCurrentProcess().MainModule.FileName);
			nameValueCollection["enckey"] = encryption.encrypt(this.enckey, this.secret, text);
			nameValueCollection["name"] = encryption.byte_arr_to_str(Encoding.Default.GetBytes(this.name));
			nameValueCollection["ownerid"] = encryption.byte_arr_to_str(Encoding.Default.GetBytes(this.ownerid));
			nameValueCollection["init_iv"] = text;
			string text2 = api.req(nameValueCollection);
			if (text2 == "KeyAuth_Invalid")
			{
				api.error("Medusa Down... Try Again");
				Environment.Exit(0);
			}
			text2 = encryption.decrypt(text2, this.secret, text);
			api.response_structure response_structure = this.response_decoder.string_to_generic<api.response_structure>(text2);
			this.load_response_struct(response_structure);
			if (response_structure.success)
			{
				this.load_app_data(response_structure.appinfo);
				this.sessionid = response_structure.sessionid;
				this.initzalized = true;
				return;
			}
			if (response_structure.message == "invalidver")
			{
				this.app_data.downloadLink = response_structure.download;
			}
		}

		// Token: 0x1700000C RID: 12
		// (get) Token: 0x0600002E RID: 46 RVA: 0x0000355D File Offset: 0x0000355D
		public static bool IsDebugRelease
		{
			get
			{
				return true;
			}
		}

		// Token: 0x0600002F RID: 47 RVA: 0x00003560 File Offset: 0x00003560
		public void Checkinit()
		{
			if (!this.initzalized)
			{
				if (api.IsDebugRelease)
				{
					api.error("Medusa Spoofer Down!");
					return;
				}
				api.error("Please initialize first");
			}
		}

		// Token: 0x06000030 RID: 48 RVA: 0x00003588 File Offset: 0x00003588
		public void register(string username, string pass, string key)
		{
			this.Checkinit();
			string value = WindowsIdentity.GetCurrent().User.Value;
			string text = encryption.sha256(encryption.iv_key());
			NameValueCollection nameValueCollection = new NameValueCollection();
			nameValueCollection["type"] = encryption.byte_arr_to_str(Encoding.Default.GetBytes("register"));
			nameValueCollection["username"] = encryption.encrypt(username, this.enckey, text);
			nameValueCollection["pass"] = encryption.encrypt(pass, this.enckey, text);
			nameValueCollection["key"] = encryption.encrypt(key, this.enckey, text);
			nameValueCollection["hwid"] = encryption.encrypt(value, this.enckey, text);
			nameValueCollection["sessionid"] = encryption.byte_arr_to_str(Encoding.Default.GetBytes(this.sessionid));
			nameValueCollection["name"] = encryption.byte_arr_to_str(Encoding.Default.GetBytes(this.name));
			nameValueCollection["ownerid"] = encryption.byte_arr_to_str(Encoding.Default.GetBytes(this.ownerid));
			nameValueCollection["init_iv"] = text;
			string text2 = api.req(nameValueCollection);
			text2 = encryption.decrypt(text2, this.enckey, text);
			api.response_structure response_structure = this.response_decoder.string_to_generic<api.response_structure>(text2);
			this.load_response_struct(response_structure);
			if (response_structure.success)
			{
				this.load_user_data(response_structure.info);
			}
		}

		// Token: 0x06000031 RID: 49 RVA: 0x000036E4 File Offset: 0x000036E4
		public void login(string username, string pass)
		{
			this.Checkinit();
			string value = WindowsIdentity.GetCurrent().User.Value;
			string text = encryption.sha256(encryption.iv_key());
			NameValueCollection nameValueCollection = new NameValueCollection();
			nameValueCollection["type"] = encryption.byte_arr_to_str(Encoding.Default.GetBytes("login"));
			nameValueCollection["username"] = encryption.encrypt(username, this.enckey, text);
			nameValueCollection["pass"] = encryption.encrypt(pass, this.enckey, text);
			nameValueCollection["hwid"] = encryption.encrypt(value, this.enckey, text);
			nameValueCollection["sessionid"] = encryption.byte_arr_to_str(Encoding.Default.GetBytes(this.sessionid));
			nameValueCollection["name"] = encryption.byte_arr_to_str(Encoding.Default.GetBytes(this.name));
			nameValueCollection["ownerid"] = encryption.byte_arr_to_str(Encoding.Default.GetBytes(this.ownerid));
			nameValueCollection["init_iv"] = text;
			string text2 = api.req(nameValueCollection);
			text2 = encryption.decrypt(text2, this.enckey, text);
			api.response_structure response_structure = this.response_decoder.string_to_generic<api.response_structure>(text2);
			this.load_response_struct(response_structure);
			if (response_structure.success)
			{
				this.load_user_data(response_structure.info);
			}
		}

		// Token: 0x06000032 RID: 50 RVA: 0x00003828 File Offset: 0x00003828
		public void upgrade(string username, string key)
		{
			this.Checkinit();
			string value = WindowsIdentity.GetCurrent().User.Value;
			string text = encryption.sha256(encryption.iv_key());
			NameValueCollection nameValueCollection = new NameValueCollection();
			nameValueCollection["type"] = encryption.byte_arr_to_str(Encoding.Default.GetBytes("upgrade"));
			nameValueCollection["username"] = encryption.encrypt(username, this.enckey, text);
			nameValueCollection["key"] = encryption.encrypt(key, this.enckey, text);
			nameValueCollection["sessionid"] = encryption.byte_arr_to_str(Encoding.Default.GetBytes(this.sessionid));
			nameValueCollection["name"] = encryption.byte_arr_to_str(Encoding.Default.GetBytes(this.name));
			nameValueCollection["ownerid"] = encryption.byte_arr_to_str(Encoding.Default.GetBytes(this.ownerid));
			nameValueCollection["init_iv"] = text;
			string text2 = api.req(nameValueCollection);
			text2 = encryption.decrypt(text2, this.enckey, text);
			api.response_structure response_structure = this.response_decoder.string_to_generic<api.response_structure>(text2);
			response_structure.success = false;
			this.load_response_struct(response_structure);
		}

		// Token: 0x06000033 RID: 51 RVA: 0x00003948 File Offset: 0x00003948
		public void license(string key)
		{
			this.Checkinit();
			string value = WindowsIdentity.GetCurrent().User.Value;
			string text = encryption.sha256(encryption.iv_key());
			NameValueCollection nameValueCollection = new NameValueCollection();
			nameValueCollection["type"] = encryption.byte_arr_to_str(Encoding.Default.GetBytes("license"));
			nameValueCollection["key"] = encryption.encrypt(key, this.enckey, text);
			nameValueCollection["hwid"] = encryption.encrypt(value, this.enckey, text);
			nameValueCollection["sessionid"] = encryption.byte_arr_to_str(Encoding.Default.GetBytes(this.sessionid));
			nameValueCollection["name"] = encryption.byte_arr_to_str(Encoding.Default.GetBytes(this.name));
			nameValueCollection["ownerid"] = encryption.byte_arr_to_str(Encoding.Default.GetBytes(this.ownerid));
			nameValueCollection["init_iv"] = text;
			string text2 = api.req(nameValueCollection);
			text2 = encryption.decrypt(text2, this.enckey, text);
			api.response_structure response_structure = this.response_decoder.string_to_generic<api.response_structure>(text2);
			this.load_response_struct(response_structure);
			if (response_structure.success)
			{
				this.load_user_data(response_structure.info);
			}
		}

		// Token: 0x06000034 RID: 52 RVA: 0x00003A74 File Offset: 0x00003A74
		public void check()
		{
			this.Checkinit();
			string text = encryption.sha256(encryption.iv_key());
			NameValueCollection nameValueCollection = new NameValueCollection();
			nameValueCollection["type"] = encryption.byte_arr_to_str(Encoding.Default.GetBytes("check"));
			nameValueCollection["sessionid"] = encryption.byte_arr_to_str(Encoding.Default.GetBytes(this.sessionid));
			nameValueCollection["name"] = encryption.byte_arr_to_str(Encoding.Default.GetBytes(this.name));
			nameValueCollection["ownerid"] = encryption.byte_arr_to_str(Encoding.Default.GetBytes(this.ownerid));
			nameValueCollection["init_iv"] = text;
			string text2 = api.req(nameValueCollection);
			text2 = encryption.decrypt(text2, this.enckey, text);
			api.response_structure data = this.response_decoder.string_to_generic<api.response_structure>(text2);
			this.load_response_struct(data);
		}

		// Token: 0x06000035 RID: 53 RVA: 0x00003B4C File Offset: 0x00003B4C
		public void setvar(string var, string data)
		{
			this.Checkinit();
			string text = encryption.sha256(encryption.iv_key());
			NameValueCollection nameValueCollection = new NameValueCollection();
			nameValueCollection["type"] = encryption.byte_arr_to_str(Encoding.Default.GetBytes("setvar"));
			nameValueCollection["var"] = encryption.encrypt(var, this.enckey, text);
			nameValueCollection["data"] = encryption.encrypt(data, this.enckey, text);
			nameValueCollection["sessionid"] = encryption.byte_arr_to_str(Encoding.Default.GetBytes(this.sessionid));
			nameValueCollection["name"] = encryption.byte_arr_to_str(Encoding.Default.GetBytes(this.name));
			nameValueCollection["ownerid"] = encryption.byte_arr_to_str(Encoding.Default.GetBytes(this.ownerid));
			nameValueCollection["init_iv"] = text;
			string text2 = api.req(nameValueCollection);
			text2 = encryption.decrypt(text2, this.enckey, text);
			api.response_structure data2 = this.response_decoder.string_to_generic<api.response_structure>(text2);
			this.load_response_struct(data2);
		}

		// Token: 0x06000036 RID: 54 RVA: 0x00003C54 File Offset: 0x00003C54
		public string getvar(string var)
		{
			this.Checkinit();
			string text = encryption.sha256(encryption.iv_key());
			NameValueCollection nameValueCollection = new NameValueCollection();
			nameValueCollection["type"] = encryption.byte_arr_to_str(Encoding.Default.GetBytes("getvar"));
			nameValueCollection["var"] = encryption.encrypt(var, this.enckey, text);
			nameValueCollection["sessionid"] = encryption.byte_arr_to_str(Encoding.Default.GetBytes(this.sessionid));
			nameValueCollection["name"] = encryption.byte_arr_to_str(Encoding.Default.GetBytes(this.name));
			nameValueCollection["ownerid"] = encryption.byte_arr_to_str(Encoding.Default.GetBytes(this.ownerid));
			nameValueCollection["init_iv"] = text;
			string text2 = api.req(nameValueCollection);
			text2 = encryption.decrypt(text2, this.enckey, text);
			api.response_structure response_structure = this.response_decoder.string_to_generic<api.response_structure>(text2);
			this.load_response_struct(response_structure);
			if (response_structure.success)
			{
				return response_structure.response;
			}
			return null;
		}

		// Token: 0x06000037 RID: 55 RVA: 0x00003D54 File Offset: 0x00003D54
		public void ban()
		{
			this.Checkinit();
			string text = encryption.sha256(encryption.iv_key());
			NameValueCollection nameValueCollection = new NameValueCollection();
			nameValueCollection["type"] = encryption.byte_arr_to_str(Encoding.Default.GetBytes("ban"));
			nameValueCollection["sessionid"] = encryption.byte_arr_to_str(Encoding.Default.GetBytes(this.sessionid));
			nameValueCollection["name"] = encryption.byte_arr_to_str(Encoding.Default.GetBytes(this.name));
			nameValueCollection["ownerid"] = encryption.byte_arr_to_str(Encoding.Default.GetBytes(this.ownerid));
			nameValueCollection["init_iv"] = text;
			string text2 = api.req(nameValueCollection);
			text2 = encryption.decrypt(text2, this.enckey, text);
			api.response_structure data = this.response_decoder.string_to_generic<api.response_structure>(text2);
			this.load_response_struct(data);
		}

		// Token: 0x06000038 RID: 56 RVA: 0x00003E2C File Offset: 0x00003E2C
		public string var(string varid)
		{
			this.Checkinit();
			string value = WindowsIdentity.GetCurrent().User.Value;
			string text = encryption.sha256(encryption.iv_key());
			NameValueCollection nameValueCollection = new NameValueCollection();
			nameValueCollection["type"] = encryption.byte_arr_to_str(Encoding.Default.GetBytes("var"));
			nameValueCollection["varid"] = encryption.encrypt(varid, this.enckey, text);
			nameValueCollection["sessionid"] = encryption.byte_arr_to_str(Encoding.Default.GetBytes(this.sessionid));
			nameValueCollection["name"] = encryption.byte_arr_to_str(Encoding.Default.GetBytes(this.name));
			nameValueCollection["ownerid"] = encryption.byte_arr_to_str(Encoding.Default.GetBytes(this.ownerid));
			nameValueCollection["init_iv"] = text;
			string text2 = api.req(nameValueCollection);
			text2 = encryption.decrypt(text2, this.enckey, text);
			api.response_structure response_structure = this.response_decoder.string_to_generic<api.response_structure>(text2);
			this.load_response_struct(response_structure);
			if (response_structure.success)
			{
				return response_structure.message;
			}
			return null;
		}

		// Token: 0x06000039 RID: 57 RVA: 0x00003F3C File Offset: 0x00003F3C
		public List<api.msg> chatget(string channelname)
		{
			this.Checkinit();
			string text = encryption.sha256(encryption.iv_key());
			NameValueCollection nameValueCollection = new NameValueCollection();
			nameValueCollection["type"] = encryption.byte_arr_to_str(Encoding.Default.GetBytes("chatget"));
			nameValueCollection["channel"] = encryption.encrypt(channelname, this.enckey, text);
			nameValueCollection["sessionid"] = encryption.byte_arr_to_str(Encoding.Default.GetBytes(this.sessionid));
			nameValueCollection["name"] = encryption.byte_arr_to_str(Encoding.Default.GetBytes(this.name));
			nameValueCollection["ownerid"] = encryption.byte_arr_to_str(Encoding.Default.GetBytes(this.ownerid));
			nameValueCollection["init_iv"] = text;
			string text2 = api.req(nameValueCollection);
			text2 = encryption.decrypt(text2, this.enckey, text);
			api.response_structure response_structure = this.response_decoder.string_to_generic<api.response_structure>(text2);
			this.load_response_struct(response_structure);
			if (response_structure.success)
			{
				return response_structure.messages;
			}
			return null;
		}

		// Token: 0x0600003A RID: 58 RVA: 0x0000403C File Offset: 0x0000403C
		public bool chatsend(string msg, string channelname)
		{
			this.Checkinit();
			string text = encryption.sha256(encryption.iv_key());
			NameValueCollection nameValueCollection = new NameValueCollection();
			nameValueCollection["type"] = encryption.byte_arr_to_str(Encoding.Default.GetBytes("chatsend"));
			nameValueCollection["message"] = encryption.encrypt(msg, this.enckey, text);
			nameValueCollection["channel"] = encryption.encrypt(channelname, this.enckey, text);
			nameValueCollection["sessionid"] = encryption.byte_arr_to_str(Encoding.Default.GetBytes(this.sessionid));
			nameValueCollection["name"] = encryption.byte_arr_to_str(Encoding.Default.GetBytes(this.name));
			nameValueCollection["ownerid"] = encryption.byte_arr_to_str(Encoding.Default.GetBytes(this.ownerid));
			nameValueCollection["init_iv"] = text;
			string text2 = api.req(nameValueCollection);
			text2 = encryption.decrypt(text2, this.enckey, text);
			api.response_structure response_structure = this.response_decoder.string_to_generic<api.response_structure>(text2);
			this.load_response_struct(response_structure);
			return response_structure.success;
		}

		// Token: 0x0600003B RID: 59 RVA: 0x00004150 File Offset: 0x00004150
		public bool checkblack()
		{
			this.Checkinit();
			string value = WindowsIdentity.GetCurrent().User.Value;
			string text = encryption.sha256(encryption.iv_key());
			NameValueCollection nameValueCollection = new NameValueCollection();
			nameValueCollection["type"] = encryption.byte_arr_to_str(Encoding.Default.GetBytes("checkblacklist"));
			nameValueCollection["hwid"] = encryption.encrypt(value, this.enckey, text);
			nameValueCollection["sessionid"] = encryption.byte_arr_to_str(Encoding.Default.GetBytes(this.sessionid));
			nameValueCollection["name"] = encryption.byte_arr_to_str(Encoding.Default.GetBytes(this.name));
			nameValueCollection["ownerid"] = encryption.byte_arr_to_str(Encoding.Default.GetBytes(this.ownerid));
			nameValueCollection["init_iv"] = text;
			string text2 = api.req(nameValueCollection);
			text2 = encryption.decrypt(text2, this.enckey, text);
			api.response_structure response_structure = this.response_decoder.string_to_generic<api.response_structure>(text2);
			this.load_response_struct(response_structure);
			return response_structure.success;
		}

		// Token: 0x0600003C RID: 60 RVA: 0x0000425C File Offset: 0x0000425C
		public string webhook(string webid, string param, string body = "", string conttype = "")
		{
			this.Checkinit();
			string text = encryption.sha256(encryption.iv_key());
			NameValueCollection nameValueCollection = new NameValueCollection();
			nameValueCollection["type"] = encryption.byte_arr_to_str(Encoding.Default.GetBytes("webhook"));
			nameValueCollection["webid"] = encryption.encrypt(webid, this.enckey, text);
			nameValueCollection["params"] = encryption.encrypt(param, this.enckey, text);
			nameValueCollection["body"] = encryption.encrypt(body, this.enckey, text);
			nameValueCollection["conttype"] = encryption.encrypt(conttype, this.enckey, text);
			nameValueCollection["sessionid"] = encryption.byte_arr_to_str(Encoding.Default.GetBytes(this.sessionid));
			nameValueCollection["name"] = encryption.byte_arr_to_str(Encoding.Default.GetBytes(this.name));
			nameValueCollection["ownerid"] = encryption.byte_arr_to_str(Encoding.Default.GetBytes(this.ownerid));
			nameValueCollection["init_iv"] = text;
			string text2 = api.req(nameValueCollection);
			text2 = encryption.decrypt(text2, this.enckey, text);
			api.response_structure response_structure = this.response_decoder.string_to_generic<api.response_structure>(text2);
			this.load_response_struct(response_structure);
			if (response_structure.success)
			{
				return response_structure.response;
			}
			return null;
		}

		// Token: 0x0600003D RID: 61 RVA: 0x000043A4 File Offset: 0x000043A4
		public byte[] download(string fileid)
		{
			this.Checkinit();
			string text = encryption.sha256(encryption.iv_key());
			NameValueCollection nameValueCollection = new NameValueCollection();
			nameValueCollection["type"] = encryption.byte_arr_to_str(Encoding.Default.GetBytes("file"));
			nameValueCollection["fileid"] = encryption.encrypt(fileid, this.enckey, text);
			nameValueCollection["sessionid"] = encryption.byte_arr_to_str(Encoding.Default.GetBytes(this.sessionid));
			nameValueCollection["name"] = encryption.byte_arr_to_str(Encoding.Default.GetBytes(this.name));
			nameValueCollection["ownerid"] = encryption.byte_arr_to_str(Encoding.Default.GetBytes(this.ownerid));
			nameValueCollection["init_iv"] = text;
			string text2 = api.req(nameValueCollection);
			text2 = encryption.decrypt(text2, this.enckey, text);
			api.response_structure response_structure = this.response_decoder.string_to_generic<api.response_structure>(text2);
			this.load_response_struct(response_structure);
			if (response_structure.success)
			{
				return encryption.str_to_byte_arr(response_structure.contents);
			}
			return null;
		}

		// Token: 0x0600003E RID: 62 RVA: 0x000044A8 File Offset: 0x000044A8
		public void log(string message)
		{
			this.Checkinit();
			string text = encryption.sha256(encryption.iv_key());
			NameValueCollection nameValueCollection = new NameValueCollection();
			nameValueCollection["type"] = encryption.byte_arr_to_str(Encoding.Default.GetBytes("log"));
			nameValueCollection["pcuser"] = encryption.encrypt(Environment.UserName, this.enckey, text);
			nameValueCollection["message"] = encryption.encrypt(message, this.enckey, text);
			nameValueCollection["sessionid"] = encryption.byte_arr_to_str(Encoding.Default.GetBytes(this.sessionid));
			nameValueCollection["name"] = encryption.byte_arr_to_str(Encoding.Default.GetBytes(this.name));
			nameValueCollection["ownerid"] = encryption.byte_arr_to_str(Encoding.Default.GetBytes(this.ownerid));
			nameValueCollection["init_iv"] = text;
			api.req(nameValueCollection);
		}

		// Token: 0x0600003F RID: 63 RVA: 0x00004590 File Offset: 0x00004590
		public static string checksum(string filename)
		{
			string result;
			using (MD5 md = MD5.Create())
			{
				using (FileStream fileStream = File.OpenRead(filename))
				{
					result = BitConverter.ToString(md.ComputeHash(fileStream)).Replace("-", "").ToLowerInvariant();
				}
			}
			return result;
		}

		// Token: 0x06000040 RID: 64 RVA: 0x00004600 File Offset: 0x00004600
		public static void error(string message)
		{
			Process.Start(new ProcessStartInfo("cmd.exe", "/c start cmd /C \"color b && title Error && echo " + message + " && timeout /t 5\"")
			{
				CreateNoWindow = true,
				RedirectStandardOutput = true,
				RedirectStandardError = true,
				UseShellExecute = false
			});
			Environment.Exit(0);
		}

		// Token: 0x06000041 RID: 65 RVA: 0x00004650 File Offset: 0x00004650
		private static string req(NameValueCollection post_data)
		{
			string result;
			try
			{
				using (WebClient webClient = new WebClient())
				{
					byte[] bytes = webClient.UploadValues("https://keyauth.win/api/1.0/", post_data);
					result = Encoding.Default.GetString(bytes);
				}
			}
			catch (WebException ex)
			{
				if (((HttpWebResponse)ex.Response).StatusCode == (HttpStatusCode)429)
				{
					api.error("You're connecting too fast to loader, slow down.");
					Environment.Exit(0);
					result = "";
				}
				else
				{
					api.error("Connection failure. Please try again, or contact us for help.");
					Environment.Exit(0);
					result = "";
				}
			}
			return result;
		}

		// Token: 0x06000042 RID: 66 RVA: 0x000046EC File Offset: 0x000046EC
		private void load_app_data(api.app_data_structure data)
		{
			this.app_data.numUsers = data.numUsers;
			this.app_data.numOnlineUsers = data.numOnlineUsers;
			this.app_data.numKeys = data.numKeys;
			this.app_data.version = data.version;
			this.app_data.customerPanelLink = data.customerPanelLink;
		}

		// Token: 0x06000043 RID: 67 RVA: 0x00004750 File Offset: 0x00004750
		private void load_user_data(api.user_data_structure data)
		{
			this.user_data.username = data.username;
			this.user_data.ip = data.ip;
			this.user_data.hwid = data.hwid;
			this.user_data.createdate = data.createdate;
			this.user_data.lastlogin = data.lastlogin;
			this.user_data.subscriptions = data.subscriptions;
		}

		// Token: 0x06000044 RID: 68 RVA: 0x000047C4 File Offset: 0x000047C4
		public string expirydaysleft()
		{
			this.Checkinit();
			DateTime d = new DateTime(1970, 1, 1, 0, 0, 0, 0, DateTimeKind.Local);
			d = d.AddSeconds((double)long.Parse(this.user_data.subscriptions[0].expiry)).ToLocalTime();
			TimeSpan timeSpan = d - DateTime.Now;
			return Convert.ToString(timeSpan.Days.ToString() + " Days " + timeSpan.Hours.ToString() + " Hours Left");
		}

		// Token: 0x06000045 RID: 69 RVA: 0x00004854 File Offset: 0x00004854
		private void load_response_struct(api.response_structure data)
		{
			this.response.success = data.success;
			this.response.message = data.message;
		}

		// Token: 0x0400000C RID: 12
		public string name;

		// Token: 0x0400000D RID: 13
		public string ownerid;

		// Token: 0x0400000E RID: 14
		public string secret;

		// Token: 0x0400000F RID: 15
		public string version;

		// Token: 0x04000010 RID: 16
		private string sessionid;

		// Token: 0x04000011 RID: 17
		private string enckey;

		// Token: 0x04000012 RID: 18
		private bool initzalized;

		// Token: 0x04000013 RID: 19
		public api.app_data_class app_data = new api.app_data_class();

		// Token: 0x04000014 RID: 20
		public api.user_data_class user_data = new api.user_data_class();

		// Token: 0x04000015 RID: 21
		public api.response_class response = new api.response_class();

		// Token: 0x04000016 RID: 22
		private json_wrapper response_decoder = new json_wrapper(new api.response_structure());

		// Token: 0x02000014 RID: 20
		[DataContract]
		private class response_structure
		{
			// Token: 0x17000017 RID: 23
			// (get) Token: 0x060000AC RID: 172 RVA: 0x0000A549 File Offset: 0x0000A549
			// (set) Token: 0x060000AD RID: 173 RVA: 0x0000A551 File Offset: 0x0000A551
			[DataMember]
			public bool success { get; set; }

			// Token: 0x17000018 RID: 24
			// (get) Token: 0x060000AE RID: 174 RVA: 0x0000A55A File Offset: 0x0000A55A
			// (set) Token: 0x060000AF RID: 175 RVA: 0x0000A562 File Offset: 0x0000A562
			[DataMember]
			public string sessionid { get; set; }

			// Token: 0x17000019 RID: 25
			// (get) Token: 0x060000B0 RID: 176 RVA: 0x0000A56B File Offset: 0x0000A56B
			// (set) Token: 0x060000B1 RID: 177 RVA: 0x0000A573 File Offset: 0x0000A573
			[DataMember]
			public string contents { get; set; }

			// Token: 0x1700001A RID: 26
			// (get) Token: 0x060000B2 RID: 178 RVA: 0x0000A57C File Offset: 0x0000A57C
			// (set) Token: 0x060000B3 RID: 179 RVA: 0x0000A584 File Offset: 0x0000A584
			[DataMember]
			public string response { get; set; }

			// Token: 0x1700001B RID: 27
			// (get) Token: 0x060000B4 RID: 180 RVA: 0x0000A58D File Offset: 0x0000A58D
			// (set) Token: 0x060000B5 RID: 181 RVA: 0x0000A595 File Offset: 0x0000A595
			[DataMember]
			public string message { get; set; }

			// Token: 0x1700001C RID: 28
			// (get) Token: 0x060000B6 RID: 182 RVA: 0x0000A59E File Offset: 0x0000A59E
			// (set) Token: 0x060000B7 RID: 183 RVA: 0x0000A5A6 File Offset: 0x0000A5A6
			[DataMember]
			public string download { get; set; }

			// Token: 0x1700001D RID: 29
			// (get) Token: 0x060000B8 RID: 184 RVA: 0x0000A5AF File Offset: 0x0000A5AF
			// (set) Token: 0x060000B9 RID: 185 RVA: 0x0000A5B7 File Offset: 0x0000A5B7
			[DataMember(IsRequired = false, EmitDefaultValue = false)]
			public api.user_data_structure info { get; set; }

			// Token: 0x1700001E RID: 30
			// (get) Token: 0x060000BA RID: 186 RVA: 0x0000A5C0 File Offset: 0x0000A5C0
			// (set) Token: 0x060000BB RID: 187 RVA: 0x0000A5C8 File Offset: 0x0000A5C8
			[DataMember(IsRequired = false, EmitDefaultValue = false)]
			public api.app_data_structure appinfo { get; set; }

			// Token: 0x1700001F RID: 31
			// (get) Token: 0x060000BC RID: 188 RVA: 0x0000A5D1 File Offset: 0x0000A5D1
			// (set) Token: 0x060000BD RID: 189 RVA: 0x0000A5D9 File Offset: 0x0000A5D9
			[DataMember]
			public List<api.msg> messages { get; set; }
		}

		// Token: 0x02000015 RID: 21
		public class msg
		{
			// Token: 0x17000020 RID: 32
			// (get) Token: 0x060000BF RID: 191 RVA: 0x0000A5EA File Offset: 0x0000A5EA
			// (set) Token: 0x060000C0 RID: 192 RVA: 0x0000A5F2 File Offset: 0x0000A5F2
			public string message { get; set; }

			// Token: 0x17000021 RID: 33
			// (get) Token: 0x060000C1 RID: 193 RVA: 0x0000A5FB File Offset: 0x0000A5FB
			// (set) Token: 0x060000C2 RID: 194 RVA: 0x0000A603 File Offset: 0x0000A603
			public string author { get; set; }

			// Token: 0x17000022 RID: 34
			// (get) Token: 0x060000C3 RID: 195 RVA: 0x0000A60C File Offset: 0x0000A60C
			// (set) Token: 0x060000C4 RID: 196 RVA: 0x0000A614 File Offset: 0x0000A614
			public string timestamp { get; set; }
		}

		// Token: 0x02000016 RID: 22
		[DataContract]
		private class user_data_structure
		{
			// Token: 0x17000023 RID: 35
			// (get) Token: 0x060000C6 RID: 198 RVA: 0x0000A625 File Offset: 0x0000A625
			// (set) Token: 0x060000C7 RID: 199 RVA: 0x0000A62D File Offset: 0x0000A62D
			[DataMember]
			public string username { get; set; }

			// Token: 0x17000024 RID: 36
			// (get) Token: 0x060000C8 RID: 200 RVA: 0x0000A636 File Offset: 0x0000A636
			// (set) Token: 0x060000C9 RID: 201 RVA: 0x0000A63E File Offset: 0x0000A63E
			[DataMember]
			public string ip { get; set; }

			// Token: 0x17000025 RID: 37
			// (get) Token: 0x060000CA RID: 202 RVA: 0x0000A647 File Offset: 0x0000A647
			// (set) Token: 0x060000CB RID: 203 RVA: 0x0000A64F File Offset: 0x0000A64F
			[DataMember]
			public string hwid { get; set; }

			// Token: 0x17000026 RID: 38
			// (get) Token: 0x060000CC RID: 204 RVA: 0x0000A658 File Offset: 0x0000A658
			// (set) Token: 0x060000CD RID: 205 RVA: 0x0000A660 File Offset: 0x0000A660
			[DataMember]
			public string createdate { get; set; }

			// Token: 0x17000027 RID: 39
			// (get) Token: 0x060000CE RID: 206 RVA: 0x0000A669 File Offset: 0x0000A669
			// (set) Token: 0x060000CF RID: 207 RVA: 0x0000A671 File Offset: 0x0000A671
			[DataMember]
			public string lastlogin { get; set; }

			// Token: 0x17000028 RID: 40
			// (get) Token: 0x060000D0 RID: 208 RVA: 0x0000A67A File Offset: 0x0000A67A
			// (set) Token: 0x060000D1 RID: 209 RVA: 0x0000A682 File Offset: 0x0000A682
			[DataMember]
			public List<api.Data> subscriptions { get; set; }
		}

		// Token: 0x02000017 RID: 23
		[DataContract]
		private class app_data_structure
		{
			// Token: 0x17000029 RID: 41
			// (get) Token: 0x060000D3 RID: 211 RVA: 0x0000A693 File Offset: 0x0000A693
			// (set) Token: 0x060000D4 RID: 212 RVA: 0x0000A69B File Offset: 0x0000A69B
			[DataMember]
			public string numUsers { get; set; }

			// Token: 0x1700002A RID: 42
			// (get) Token: 0x060000D5 RID: 213 RVA: 0x0000A6A4 File Offset: 0x0000A6A4
			// (set) Token: 0x060000D6 RID: 214 RVA: 0x0000A6AC File Offset: 0x0000A6AC
			[DataMember]
			public string numOnlineUsers { get; set; }

			// Token: 0x1700002B RID: 43
			// (get) Token: 0x060000D7 RID: 215 RVA: 0x0000A6B5 File Offset: 0x0000A6B5
			// (set) Token: 0x060000D8 RID: 216 RVA: 0x0000A6BD File Offset: 0x0000A6BD
			[DataMember]
			public string numKeys { get; set; }

			// Token: 0x1700002C RID: 44
			// (get) Token: 0x060000D9 RID: 217 RVA: 0x0000A6C6 File Offset: 0x0000A6C6
			// (set) Token: 0x060000DA RID: 218 RVA: 0x0000A6CE File Offset: 0x0000A6CE
			[DataMember]
			public string version { get; set; }

			// Token: 0x1700002D RID: 45
			// (get) Token: 0x060000DB RID: 219 RVA: 0x0000A6D7 File Offset: 0x0000A6D7
			// (set) Token: 0x060000DC RID: 220 RVA: 0x0000A6DF File Offset: 0x0000A6DF
			[DataMember]
			public string customerPanelLink { get; set; }

			// Token: 0x1700002E RID: 46
			// (get) Token: 0x060000DD RID: 221 RVA: 0x0000A6E8 File Offset: 0x0000A6E8
			// (set) Token: 0x060000DE RID: 222 RVA: 0x0000A6F0 File Offset: 0x0000A6F0
			[DataMember]
			public string downloadLink { get; set; }
		}

		// Token: 0x02000018 RID: 24
		public class app_data_class
		{
			// Token: 0x1700002F RID: 47
			// (get) Token: 0x060000E0 RID: 224 RVA: 0x0000A701 File Offset: 0x0000A701
			// (set) Token: 0x060000E1 RID: 225 RVA: 0x0000A709 File Offset: 0x0000A709
			public string numUsers { get; set; }

			// Token: 0x17000030 RID: 48
			// (get) Token: 0x060000E2 RID: 226 RVA: 0x0000A712 File Offset: 0x0000A712
			// (set) Token: 0x060000E3 RID: 227 RVA: 0x0000A71A File Offset: 0x0000A71A
			public string numOnlineUsers { get; set; }

			// Token: 0x17000031 RID: 49
			// (get) Token: 0x060000E4 RID: 228 RVA: 0x0000A723 File Offset: 0x0000A723
			// (set) Token: 0x060000E5 RID: 229 RVA: 0x0000A72B File Offset: 0x0000A72B
			public string numKeys { get; set; }

			// Token: 0x17000032 RID: 50
			// (get) Token: 0x060000E6 RID: 230 RVA: 0x0000A734 File Offset: 0x0000A734
			// (set) Token: 0x060000E7 RID: 231 RVA: 0x0000A73C File Offset: 0x0000A73C
			public string version { get; set; }

			// Token: 0x17000033 RID: 51
			// (get) Token: 0x060000E8 RID: 232 RVA: 0x0000A745 File Offset: 0x0000A745
			// (set) Token: 0x060000E9 RID: 233 RVA: 0x0000A74D File Offset: 0x0000A74D
			public string customerPanelLink { get; set; }

			// Token: 0x17000034 RID: 52
			// (get) Token: 0x060000EA RID: 234 RVA: 0x0000A756 File Offset: 0x0000A756
			// (set) Token: 0x060000EB RID: 235 RVA: 0x0000A75E File Offset: 0x0000A75E
			public string downloadLink { get; set; }
		}

		// Token: 0x02000019 RID: 25
		public class user_data_class
		{
			// Token: 0x17000035 RID: 53
			// (get) Token: 0x060000ED RID: 237 RVA: 0x0000A76F File Offset: 0x0000A76F
			// (set) Token: 0x060000EE RID: 238 RVA: 0x0000A777 File Offset: 0x0000A777
			public string username { get; set; }

			// Token: 0x17000036 RID: 54
			// (get) Token: 0x060000EF RID: 239 RVA: 0x0000A780 File Offset: 0x0000A780
			// (set) Token: 0x060000F0 RID: 240 RVA: 0x0000A788 File Offset: 0x0000A788
			public string ip { get; set; }

			// Token: 0x17000037 RID: 55
			// (get) Token: 0x060000F1 RID: 241 RVA: 0x0000A791 File Offset: 0x0000A791
			// (set) Token: 0x060000F2 RID: 242 RVA: 0x0000A799 File Offset: 0x0000A799
			public string hwid { get; set; }

			// Token: 0x17000038 RID: 56
			// (get) Token: 0x060000F3 RID: 243 RVA: 0x0000A7A2 File Offset: 0x0000A7A2
			// (set) Token: 0x060000F4 RID: 244 RVA: 0x0000A7AA File Offset: 0x0000A7AA
			public string createdate { get; set; }

			// Token: 0x17000039 RID: 57
			// (get) Token: 0x060000F5 RID: 245 RVA: 0x0000A7B3 File Offset: 0x0000A7B3
			// (set) Token: 0x060000F6 RID: 246 RVA: 0x0000A7BB File Offset: 0x0000A7BB
			public string lastlogin { get; set; }

			// Token: 0x1700003A RID: 58
			// (get) Token: 0x060000F7 RID: 247 RVA: 0x0000A7C4 File Offset: 0x0000A7C4
			// (set) Token: 0x060000F8 RID: 248 RVA: 0x0000A7CC File Offset: 0x0000A7CC
			public List<api.Data> subscriptions { get; set; }
		}

		// Token: 0x0200001A RID: 26
		public class Data
		{
			// Token: 0x1700003B RID: 59
			// (get) Token: 0x060000FA RID: 250 RVA: 0x0000A7DD File Offset: 0x0000A7DD
			// (set) Token: 0x060000FB RID: 251 RVA: 0x0000A7E5 File Offset: 0x0000A7E5
			public string subscription { get; set; }

			// Token: 0x1700003C RID: 60
			// (get) Token: 0x060000FC RID: 252 RVA: 0x0000A7EE File Offset: 0x0000A7EE
			// (set) Token: 0x060000FD RID: 253 RVA: 0x0000A7F6 File Offset: 0x0000A7F6
			public string expiry { get; set; }

			// Token: 0x1700003D RID: 61
			// (get) Token: 0x060000FE RID: 254 RVA: 0x0000A7FF File Offset: 0x0000A7FF
			// (set) Token: 0x060000FF RID: 255 RVA: 0x0000A807 File Offset: 0x0000A807
			public string timeleft { get; set; }
		}

		// Token: 0x0200001B RID: 27
		public class response_class
		{
			// Token: 0x1700003E RID: 62
			// (get) Token: 0x06000101 RID: 257 RVA: 0x0000A818 File Offset: 0x0000A818
			// (set) Token: 0x06000102 RID: 258 RVA: 0x0000A820 File Offset: 0x0000A820
			public bool success { get; set; }

			// Token: 0x1700003F RID: 63
			// (get) Token: 0x06000103 RID: 259 RVA: 0x0000A829 File Offset: 0x0000A829
			// (set) Token: 0x06000104 RID: 260 RVA: 0x0000A831 File Offset: 0x0000A831
			public string message { get; set; }
		}
	}
}
