using System;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Json;
using System.Text;

namespace KeyAuth
{
	// Token: 0x0200000B RID: 11
	public class json_wrapper
	{
		// Token: 0x0600004E RID: 78 RVA: 0x00004B97 File Offset: 0x00004B97
		public static bool is_serializable(Type to_check)
		{
			return to_check.IsSerializable || to_check.IsDefined(typeof(DataContractAttribute), true);
		}

		// Token: 0x0600004F RID: 79 RVA: 0x00004BB4 File Offset: 0x00004BB4
		public json_wrapper(object obj_to_work_with)
		{
			this.current_object = obj_to_work_with;
			Type type = this.current_object.GetType();
			this.serializer = new DataContractJsonSerializer(type);
			if (!json_wrapper.is_serializable(type))
			{
				throw new Exception(string.Format("the object {0} isn't a serializable", this.current_object));
			}
		}

		// Token: 0x06000050 RID: 80 RVA: 0x00004C04 File Offset: 0x00004C04
		public object string_to_object(string json)
		{
			object result;
			using (MemoryStream memoryStream = new MemoryStream(Encoding.Default.GetBytes(json)))
			{
				result = this.serializer.ReadObject(memoryStream);
			}
			return result;
		}

		// Token: 0x06000051 RID: 81 RVA: 0x00004C4C File Offset: 0x00004C4C
		public T string_to_generic<T>(string json)
		{
			return (T)((object)this.string_to_object(json));
		}

		// Token: 0x04000017 RID: 23
		private DataContractJsonSerializer serializer;

		// Token: 0x04000018 RID: 24
		private object current_object;
	}
}
