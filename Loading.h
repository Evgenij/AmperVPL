//---------------------------------------------------------------------------

#ifndef LoadingH
#define LoadingH
//---------------------------------------------------------------------------
#include <System.Classes.hpp>
#include <Vcl.Controls.hpp>
#include <Vcl.StdCtrls.hpp>
#include <Vcl.Forms.hpp>
#include <Vcl.ExtCtrls.hpp>
#include <Vcl.Imaging.pngimage.hpp>
#include <Vcl.ComCtrls.hpp>
//---------------------------------------------------------------------------
class TLoad : public TForm
{
__published:	// IDE-managed Components
	TImage *Image1;
	TProgressBar *ProgressBar1;
	TLabel *Label1;
	TTimer *Timer1;
	void __fastcall Timer1Timer(TObject *Sender);
private:	// User declarations
public:		// User declarations
	__fastcall TLoad(TComponent* Owner);
};
//---------------------------------------------------------------------------
extern PACKAGE TLoad *Load;
//---------------------------------------------------------------------------
#endif
