//---------------------------------------------------------------------------

#include <vcl.h>
#pragma hdrstop
#include <tchar.h>
//---------------------------------------------------------------------------
#include <Vcl.Styles.hpp>
#include <Vcl.Themes.hpp>
USEFORM("MainWindow.cpp", Main);
USEFORM("lab1_info.cpp", lab_inf);
USEFORM("Value_tabl.cpp", FValue);
USEFORM("Menu.cpp", NMenu);
USEFORM("Lab.cpp", FProjects);
USEFORM("Answer.cpp", FAnswer);
USEFORM("info.cpp", FInfo);
//---------------------------------------------------------------------------
int WINAPI _tWinMain(HINSTANCE, HINSTANCE, LPTSTR, int)
{
	try
	{
		Application->Initialize();
		Application->MainFormOnTaskBar = true;
		TStyleManager::TrySetStyle("Windows10 Dark");
		Application->CreateForm(__classid(TNMenu), &NMenu);
		Application->CreateForm(__classid(TFProjects), &FProjects);
		Application->CreateForm(__classid(TMain), &Main);
		Application->CreateForm(__classid(Tlab_inf), &lab_inf);
		Application->CreateForm(__classid(TFValue), &FValue);
		Application->CreateForm(__classid(TFAnswer), &FAnswer);
		Application->CreateForm(__classid(TFInfo), &FInfo);
		Application->Run();
	}
	catch (Exception &exception)
	{
		Application->ShowException(&exception);
	}
	catch (...)
	{
		try
		{
			throw Exception("");
		}
		catch (Exception &exception)
		{
			Application->ShowException(&exception);
		}
	}
	return 0;
}
//---------------------------------------------------------------------------
