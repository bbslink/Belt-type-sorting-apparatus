DLLÊÚÈ¨Âë£¨AdminCode£©£º
ppnn13%dkstFeb.1st

string AdministratorCode = "ppnn13%dkstFeb.1st";
private string adminCode="";
public string AdminCode
{
      get { return adminCode; }
      set { adminCode = value; }
}


//ÊÚÈ¨Âë
string AdministratorCode = "ppnn13%dkstFeb.1st";
string adminCode="";

if (!AdminCode.Equals(AdministratorCode))
{
     errMsg = "ÊÚÈ¨Âë´íÎó!";
     return false;
}

if (!AdminCode.Equals(AdministratorCode))
{
     MessageBox.Show("ÊÓ¾õ¿Ø¼şÊÚÈ¨Âë´íÎó!");
     return;
}