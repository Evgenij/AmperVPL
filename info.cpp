//---------------------------------------------------------------------------

#include <vcl.h>
#pragma hdrstop

#include "info.h"
//---------------------------------------------------------------------------
#pragma package(smart_init)
#pragma resource "*.dfm"
TFInfo *FInfo;
//---------------------------------------------------------------------------
__fastcall TFInfo::TFInfo(TComponent* Owner)
	: TForm(Owner)
{
}
//---------------------------------------------------------------------------
void __fastcall TFInfo::Image2MouseEnter(TObject *Sender)
{
	Image2->Picture->LoadFromFile("left_1.png");
}
//---------------------------------------------------------------------------
void __fastcall TFInfo::Image2MouseLeave(TObject *Sender)
{
	Image2->Picture->LoadFromFile("left.png");
}
//---------------------------------------------------------------------------
void __fastcall TFInfo::Image2Click(TObject *Sender)
{
    FInfo->Close();
}
//---------------------------------------------------------------------------
