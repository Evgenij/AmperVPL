//---------------------------------------------------------------------------

#include <vcl.h>
#pragma hdrstop

#include "Loading.h"
#include "Project1PCH1.h"
#include "MainMenu.h"
#include "MainWindow.h"
#include "Projects.h"
//---------------------------------------------------------------------------
#pragma package(smart_init)
#pragma resource "*.dfm"
TLoad *Load;
//---------------------------------------------------------------------------
__fastcall TLoad::TLoad(TComponent* Owner)
	: TForm(Owner)
{
}
//---------------------------------------------------------------------------

void __fastcall TLoad::Timer1Timer(TObject *Sender)
{
	for(int i=0;i<=15;i+=1)
	{
		ProgressBar1->Position+=1;
		if(ProgressBar1->Position==100)
		{
			Timer1->Enabled=false;
			Load->Close();
		}
	}
}
//---------------------------------------------------------------------------

