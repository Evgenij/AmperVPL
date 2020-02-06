//---------------------------------------------------------------------------

#include <vcl.h>
#pragma hdrstop

#include "MainWindow.h"
#include "MainMenu.h"
#include "Projects.h"
#include "Elements.h"
#include "lab1_info.h"
#include "Value_tabl.h"
#include "AmperPCH1.h"
#include "Value_for_6.h"
#include "Answer.h"
#include "Menu.h"
#include "Lab.h"
//---------------------------------------------------------------------------
#pragma package(smart_init)
#pragma resource "*.dfm"
TMain *Main;
extern int nlab;
//---------------------------------------------------------------------------
__fastcall TMain::TMain(TComponent* Owner)
	: TForm(Owner)
{
}
void __fastcall TMain::FormActivate(TObject *Sender)
{
	Bottom->Color=0x00181818;
	Bottom->SendToBack();
}
//---------------------------------------------------------------------------

void __fastcall TMain::Button3Click(TObject *Sender)
{
	FProjects->lab->Destroying();
	FProjects->lab->Close();
	NMenu->Close();
}
//---------------------------------------------------------------------------

void __fastcall TMain::Image2MouseEnter(TObject *Sender)
{
	Image2->Picture->LoadFromFile("tabl1.png");
}
//---------------------------------------------------------------------------

void __fastcall TMain::Image2MouseLeave(TObject *Sender)
{
	Image2->Picture->LoadFromFile("tabl.png");
}
//---------------------------------------------------------------------------

void __fastcall TMain::Image2Click(TObject *Sender)
{
    FValue->Show();
}
//---------------------------------------------------------------------------

void __fastcall TMain::Image1Click(TObject *Sender)
{
    if(nlab==1)
	{
		FProjects->lab->Destroying();
		FProjects->lab->Hide();
		lab_inf->Show();
	}
	else if(nlab==6)
	{
		FProjects->lab->Destroying();
		FProjects->lab->Hide();
		FProjects->Show();
		FValue->SG2->Destroying();
		FValue->Height=213;
	}
	else if(nlab>1)
	{
		FProjects->lab->Destroying();
		FProjects->lab->Hide();
		FProjects->Show();
	}
}
//---------------------------------------------------------------------------

void __fastcall TMain::Image1MouseEnter(TObject *Sender)
{
	Image1->Picture->LoadFromFile("left_1.png");
}
//---------------------------------------------------------------------------

void __fastcall TMain::Image1MouseLeave(TObject *Sender)
{
	Image1->Picture->LoadFromFile("left.png");
}
//---------------------------------------------------------------------------

void __fastcall TMain::FormClose(TObject *Sender, TCloseAction &Action)
{
	NMenu->Close();
}
//---------------------------------------------------------------------------

