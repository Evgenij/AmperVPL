//---------------------------------------------------------------------------

#ifndef infoH
#define infoH
//---------------------------------------------------------------------------
#include <System.Classes.hpp>
#include <Vcl.Controls.hpp>
#include <Vcl.StdCtrls.hpp>
#include <Vcl.Forms.hpp>
#include <Vcl.ExtCtrls.hpp>
#include <Vcl.Imaging.pngimage.hpp>
//---------------------------------------------------------------------------
class TFInfo : public TForm
{
__published:	// IDE-managed Components
	TImage *Image1;
	TImage *Image2;
	void __fastcall Image2MouseEnter(TObject *Sender);
	void __fastcall Image2MouseLeave(TObject *Sender);
	void __fastcall Image2Click(TObject *Sender);
private:	// User declarations
public:		// User declarations
	__fastcall TFInfo(TComponent* Owner);
};
//---------------------------------------------------------------------------
extern PACKAGE TFInfo *FInfo;
//---------------------------------------------------------------------------
#endif
