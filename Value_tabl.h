//---------------------------------------------------------------------------

#ifndef Value_tablH
#define Value_tablH
//---------------------------------------------------------------------------
#include <System.Classes.hpp>
#include <Vcl.Controls.hpp>
#include <Vcl.StdCtrls.hpp>
#include <Vcl.Forms.hpp>
#include <Vcl.Grids.hpp>
#include <Vcl.ExtCtrls.hpp>
#include <Vcl.Imaging.pngimage.hpp>
//---------------------------------------------------------------------------
class TFValue : public TForm
{
__published:	// IDE-managed Components
	TStringGrid *SG;
	TStringGrid *SG2;
	TPanel *Panel1;
	TImage *Image2;
	TImage *Image1;
	TImage *Image3;
	void __fastcall Button1Click(TObject *Sender);
	void __fastcall SGDrawCell(TObject *Sender, int ACol, int ARow, TRect &Rect, TGridDrawState State);
	void __fastcall FormActivate(TObject *Sender);
	void __fastcall Button2Click(TObject *Sender);
	void __fastcall Button3Click(TObject *Sender);
	void __fastcall InExcell(TStringGrid *SGt);
	void __fastcall FormCreate(TObject *Sender);
	void __fastcall Image1Click(TObject *Sender);
	void __fastcall Image2MouseEnter(TObject *Sender);
	void __fastcall Image2MouseLeave(TObject *Sender);
	void __fastcall Image1MouseEnter(TObject *Sender);
	void __fastcall Image1MouseLeave(TObject *Sender);
	void __fastcall Image3MouseEnter(TObject *Sender);
	void __fastcall Image3MouseLeave(TObject *Sender);
	void __fastcall Image2Click(TObject *Sender);
	void __fastcall Image3Click(TObject *Sender);
private:	// User declarations
public:		// User declarations
	__fastcall TFValue(TComponent* Owner);
};
//---------------------------------------------------------------------------
extern PACKAGE TFValue *FValue;
//---------------------------------------------------------------------------
#endif
