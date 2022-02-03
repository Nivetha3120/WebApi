using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.ComponentModel.DataAnnotations;

namespace API.Model
{
public class dataprop
{
    [Key]
    public int movieid {get; set;}
    public string moviename {get; set;}
    public string language {get; set;}
    public string genre {get; set;}
}

}