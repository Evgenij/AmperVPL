//---------------------------------------------------------------------------

#ifndef lab1_infoH
#define lab1_infoH
//---------------------------------------------------------------------------
#include <System.Classes.hpp>
#include <Vcl.Controls.hpp>
#include <Vcl.StdCtrls.hpp>
#include <Vcl.Forms.hpp>
#include <Vcl.ExtCtrls.hpp>
#include <Vcl.Imaging.pngimage.hpp>
//---------------------------------------------------------------------------
class Tlab_inf : public TForm
{
__published:
	TImage *Image3;
	TImage *Image1;
	TImage *Image2;
	TImage *Image4;
	TLabel *Label1;
	TLabel *t3;
	TLabel *t4;
	TLabel *t5;
	TLabel *R;
	TLabel *I;
	TLabel *U;
	TImage *Image5;
	void __fastcall FormActivate(TObject *Sender);
	void __fastcall Image3MouseEnter(TObject *Sender);
	void __fastcall Image3MouseLeave(TObject *Sender);
	void __fastcall Image1MouseEnter(TObject *Sender);
	void __fastcall Image1MouseLeave(TObject *Sender);
	void __fastcall Image3Click(TObject *Sender);
	void __fastcall Image1Click(TObject *Sender);
	void __fastcall Button1Click(TObject *Sender);
	void __fastcall Image5MouseEnter(TObject *Sender);
	void __fastcall Image5MouseLeave(TObject *Sender);
	void __fastcall Image5Click(TObject *Sender);
private:	// User declarations
public:		// User declarations
	__fastcall Tlab_inf(TComponent* Owner);
};
//---------------------------------------------------------------------------
extern PACKAGE Tlab_inf *lab_inf;
//---------------------------------------------------------------------------
#endif
