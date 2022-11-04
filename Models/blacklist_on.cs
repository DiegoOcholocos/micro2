using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace micro2.Models
{
    [Serializable]
    public class blacklist_on
    {
    [Key]
    public string nro_doc {get;set;}
	public byte estado {get;set;}
    }
}