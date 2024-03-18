using System;
namespace BordsBokning.Models

{
	public class Bokning
	{
		
         
            public int Id { get; set; }
            public string KundNamn { get; set; }
            public DateTime BokningsDatum { get; set; }
            public int AntalPersoner { get; set; }
      


    }
}

