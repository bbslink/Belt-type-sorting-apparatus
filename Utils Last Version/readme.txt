DLL��Ȩ�루AdminCode����
ppnn13%dkstFeb.1st

string AdministratorCode = "ppnn13%dkstFeb.1st";
private string adminCode="";
public string AdminCode
{
      get { return adminCode; }
      set { adminCode = value; }
}


//��Ȩ��
string AdministratorCode = "ppnn13%dkstFeb.1st";
string adminCode="";

if (!AdminCode.Equals(AdministratorCode))
{
     errMsg = "��Ȩ�����!";
     return false;
}

if (!AdminCode.Equals(AdministratorCode))
{
     MessageBox.Show("�Ӿ��ؼ���Ȩ�����!");
     return;
}