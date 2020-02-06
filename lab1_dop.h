//---------------------------------------------------------------------------

#ifndef lab1_dopH
#define lab1_dopH
//---------------------------------------------------------------------------
#include <System.Classes.hpp>
#include <Vcl.Controls.hpp>
#include <Vcl.StdCtrls.hpp>
#include <Vcl.Forms.hpp>
#include <Vcl.ExtCtrls.hpp>
#include <Vcl.Imaging.pngimage.hpp>
//---------------------------------------------------------------------------
class Tlab1_info : public TForm
{
__published:	// IDE-managed Components
	TPanel *Panel1;
	TImage *Image1;
private:	// User declarations
public:		// User declarations
	__fastcall Tlab1_info(TComponent* Owner);
};
//---------------------------------------------------------------------------
extern PACKAGE Tlab1_info *lab1_info;
//---------------------------------------------------------------------------
#endif
