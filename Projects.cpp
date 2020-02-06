// ---------------------------------------------------------------------------

#include <vcl.h>
#pragma hdrstop

#include "Projects.h"
#include "MainMenu.h"
#include "MainWindow.h"
#include "JPEG.hpp"
#include "lab1_info.h"
#include "Elements.h"
#include "Value_tabl.h"
#include "AmperPCH1.h"
#include "Value_for_6.h"
#include "Answer.h"
#include "Menu.h"
#include "Lab.h"
// ---------------------------------------------------------------------------
#pragma package(smart_init)
#pragma resource "*.dfm"
TFProject *FProject;
/*
int nlab;

extern Battery B;
extern Reostat Reost;
extern Resistor *Res;
extern Amper A;
extern Volt *V;
extern Perekl P;
extern Lamp L;
extern Fire F;
extern Temp T;
extern Dir D;
extern RLC RLC;
extern Dir2 D2;
extern Condens C;
extern String s;
extern Lines Lns;

int type;
extern int l,r1, r2, r3;
extern float i, p, v, r12;
extern float Sk,dk,lk,Ek,R1k,R2k;
int r01, r02, temp, go, count;
float u1_7,u2_7,r1_7,r2_7,i1_7,i2_7,r_7,Ei_7;

// ---------------------------------------------------------------------------
__fastcall TFProject::TFProject(TComponent* Owner) : TForm(Owner) {
}

// ---------------------------------------------------------------------------
void __fastcall TFProject::Button1Click(TObject *Sender)
{
	FProjects->Close();
	FormMenu->Show();
}

// ----------------------------------------------------------------------------
void __fastcall TFProject::im1MouseEnter(TObject *Sender)
{
	Im_1->Visible = true;
}
// ---------------------------------------------------------------------------

void __fastcall TFProject::im1MouseLeave(TObject *Sender)
{
	Im_1->Visible = false;
}
// ---------------------------------------------------------------------------

void __fastcall TFProject::im2MouseEnter(TObject *Sender)
{
	Im_2->Visible = true;
}
// ---------------------------------------------------------------------------

void __fastcall TFProject::im2MouseLeave(TObject *Sender)
{
	Im_2->Visible = false;
}
// ---------------------------------------------------------------------------

void __fastcall TFProject::im3MouseEnter(TObject *Sender)
{
	Im_3->Visible = true;
}
// ---------------------------------------------------------------------------

void __fastcall TFProject::im3MouseLeave(TObject *Sender)
{
	Im_3->Visible = false;
}
// ---------------------------------------------------------------------------

void __fastcall TFProject::im4MouseEnter(TObject *Sender)
{
	Im_4->Visible = true;
}
// ---------------------------------------------------------------------------

void __fastcall TFProject::im4MouseLeave(TObject *Sender)
{
	Im_4->Visible = false;
}
// ---------------------------------------------------------------------------

void __fastcall TFProject::im5MouseEnter(TObject *Sender)
{
	Im_5->Visible = true;
}
// ---------------------------------------------------------------------------

void __fastcall TFProject::im5MouseLeave(TObject *Sender)
{
	Im_5->Visible = false;
}
// ---------------------------------------------------------------------------

void __fastcall TFProject::im7MouseEnter(TObject *Sender)
{
	Im_7->Visible = true;
}
// ---------------------------------------------------------------------------

void __fastcall TFProject::im7MouseLeave(TObject *Sender)
{
	Im_7->Visible = false;
}
// ---------------------------------------------------------------------------

void __fastcall TFProject::im8MouseEnter(TObject *Sender)
{
	Im_8->Visible = true;
}
// ---------------------------------------------------------------------------

void __fastcall TFProject::im8MouseLeave(TObject *Sender)
{
	Im_8->Visible = false;
}
// ---------------------------------------------------------------------------

void __fastcall TFProject::FormActivate(TObject *Sender)
{
	Panel1->Color = 0x00181818;
	int a=MessageDlg("������ ��������� �������� � ��������� ����?",mtInformation,TMsgDlgButtons()<<mbOK<<mbNo,0);
	if(a==mrOk)
	{
		SD->Execute();
		FProjects->memo=new TMemo(FProjects);
		FProjects->memo->Parent=FProjects;
        FProjects->memo->Visible=false;
	}
	else
	{
		//-
	}
}
// ---------------------------------------------------------------------------

void __fastcall TFProject::im1Click(TObject *Sender)
{
	nlab = 1;
	FProjects->Close();
	lab_inf->ShowModal();
}

// ---------------------------------------------------------------------------
void __fastcall TFProject::im2Click(TObject *Sender)
{
	nlab=2;
	FProjects->lab = new TMain(Main);
	FProjects->lab->Caption = "������������ ������ �2";

	if(memo!=NULL)
	{
		count=1;

		FProjects->memo->Lines->Add("������������ ������ �2");
		FProjects->memo->Lines->Add("����: ������������ ����������� ��������, ������������ ������ �����������, �� ���������� �� �� �������");
		FProjects->memo->Lines->Add("����: ����������� ����������� �������� �� ����������");
		FProjects->memo->Lines->Add("------------��� ������-----------");
		FProjects->memo->Lines->SaveToFile(FProjects->SD->FileName);
	}

	B.create(240, 220);
	L.create(540, 230);
	A.create(780, 350);
	V[0].create(540,60);
	Reost.create(530, 480);
	P.create(280, 480);
	P.active=false;

	TPanel *p1 = new TPanel(Main);
	p1->Parent = FProjects->lab;
	p1->Height = 85;
	p1->Width = 320;
	p1->Top = 640;
	p1->StyleElements >> seClient;
	p1->BevelOuter = bvNone;
	p1->Left = 575;
	p1->Color = 0x00FF7B00;

	TLabel *t1 = new TLabel(Main);
	t1->Parent = p1;
	t1->Left = 15;
	t1->ParentColor = false;
	t1->ParentFont = false;
	t1->StyleElements << seFont;
	t1->Font->Color = clBlack;
	t1->Caption = "P";
	t1->Font->Size = 50;

	TLabel *t2 = new TLabel(Main);
	t2->Parent = p1;
	t2->Top=54;
	t2->Left = 35;
	t2->ParentColor = false;
	t2->ParentFont = false;
	t2->StyleElements << seFont;
	t2->Font->Color = clBlack;
	t2->Caption = "�����";
	t2->Font->Size = 10;

	Pl = new TLabel(Main);
	Pl->Parent = p1;
	Pl->Top = 18;
	Pl->Left = 100;
	Pl->ParentColor = false;
	Pl->ParentFont = false;
	Pl->StyleElements << seFont;
	Pl->Font->Color = clBlack;
	Pl->Caption = "1 ��";
	Pl->Font->Size = 30;

    TPanel *p3 = new TPanel(Main);
	p3->Parent = FProjects->lab;
	p3->Height = 85;
	p3->Width = 230;
	p3->Top = 640;
	p3->StyleElements >> seClient;
	p3->BevelOuter = bvNone;
	p3->Left = 15;
	p3->Color = 0x00FF7B00;

	TLabel *t7 = new TLabel(Main);
	t7->Parent = p3;
	t7->Left = 20;
	t7->ParentColor = false;
	t7->ParentFont = false;
	t7->StyleElements << seFont;
	t7->Font->Color = clBlack;
	t7->Caption = "I";
	t7->Font->Size = 50;

	I = new TLabel(Main);
	I->Parent = p3;
	I->Top = 18;
	I->Left = 70;
	I->ParentColor = false;
	I->ParentFont = false;
	I->StyleElements << seFont;
	I->Font->Color = clBlack;
	I->Caption = "1,00 A";
	I->Font->Size = 30;

	TPanel *p4 = new TPanel(Main);
	p4->Parent = FProjects->lab;
	p4->Height = 85;
	p4->Width = 300;
	p4->Top = 640;
	p4->StyleElements >> seClient;
	p4->BevelOuter = bvNone;
	p4->Left = 260;
	p4->Color = 0x00FF7B00;

	TLabel *t8 = new TLabel(Main);
	t8->Parent = p4;
	t8->Left = 20;
	t8->ParentColor = false;
	t8->ParentFont = false;
	t8->StyleElements << seFont;
	t8->Font->Color = clBlack;
	t8->Caption = "U";
	t8->Font->Size = 50;

	TLabel *t9 = new TLabel(Main);
	t9->Parent = p4;
	t9->Top=54;
	t9->Left = 65;
	t9->ParentColor = false;
	t9->ParentFont = false;
	t9->StyleElements << seFont;
	t9->Font->Color = clBlack;
	t9->Caption = "�� �����";
	t9->Font->Size = 10;

	U = new TLabel(Main);
	U->Parent = p4;
	U->Top = 18;
	U->Left = 140;
	U->ParentColor = false;
	U->ParentFont = false;
	U->StyleElements << seFont;
	U->Font->Color = clBlack;
	U->Caption = "1,00 �";
	U->Font->Size = 30;

	FProjects->lab->Repaint();

    FValue->SG->ColCount=6;
	FValue->Width=560;
	FValue->SG->Width=540;
	FValue->SG->Cells[1][0]="U, �";
	FValue->SG->Cells[2][0]="R �����, ��";
	FValue->SG->Cells[3][0]="I, �";
	FValue->SG->Cells[4][0]="U �����, �";
	FValue->SG->Cells[5][0]="P �����, ��";

    for(int i=1;i<=FValue->SG->RowCount;i++)
	{
		for(int j=1;j<=FValue->SG->ColCount;j++)
		{
			FValue->SG->Cells[j][i]="";
		}
	}

	FProjects->lab->Show();
	Lns.paint("r");
	FProjects->Hide();
}
// ---------------------------------------------------------------------------

void __fastcall TFProject::im3Click(TObject *Sender)
{
	type=1;
	nlab = 3;
	FProjects->lab = new TMain(Main);
	FProjects->lab->Caption = "������������ ������ �3";

	if(FProjects->memo!=NULL)
	{
		count=1;

		FProjects->memo->Lines->Add("������������ ������ �3");
		FProjects->memo->Lines->Add("����: ��������� ��������� ������������� ����������� ������� ���������� � ����������");
		FProjects->memo->Lines->Add("����: ���������� �������� ������������� ������������� ����������� ������� ���������� � ����������.");
		FProjects->memo->Lines->Add("------------��� ������-----------");
		FProjects->memo->Lines->SaveToFile(FProjects->SD->FileName);
	}

	TPanel *p = new TPanel(Main);
	p->Parent = FProjects->lab;
	p->Height = 85;
	p->Width = 410;
	p->Top = 640;
	p->StyleElements >> seClient;
	p->BevelOuter = bvNone;
	p->Left = 600;
	p->Color = 0x00FF7B00;

	TLabel *r1 = new TLabel(Main);
	r1->Parent = p;
	r1->Top=12;
	r1->Left = 15;
	r1->ParentColor = false;
	r1->ParentFont = false;
	r1->StyleElements << seFont;
	r1->Font->Color = clBlack;
	r1->Caption = "�������� ����. R1";
	r1->Font->Size = 17;

	TLabel *r2 = new TLabel(Main);
	r2->Parent = p;
	r2->Top=48;
	r2->Left = 15;
	r2->ParentColor = false;
	r2->ParentFont = false;
	r2->StyleElements << seFont;
	r2->Font->Color = clBlack;
	r2->Caption = "�������� ����. R2";
	r2->Font->Size = 17;

	two = new TLabel(Main);
	two->Parent = p;
	two->Top=12;
	two->Left = 240;
	two->ParentColor = false;
	two->ParentFont = false;
	two->StyleElements << seFont;
	two->Font->Color = clBlack;
	two->Caption = "-//-";
	two->Font->Size = 17;

	four = new TLabel(Main);
	four->Parent = p;
	four->Top=48;
	four->Left = 240;
	four->ParentColor = false;
	four->ParentFont = false;
	four->StyleElements << seFont;
	four->Font->Color = clBlack;
	four->Caption = "-//-";
	four->Font->Size = 17;

	TPanel *p1 = new TPanel(Main);
	p1->Parent = FProjects->lab;
	p1->Height = 85;
	p1->Width = 280;
	p1->Top = 640;
	p1->StyleElements >> seClient;
	p1->BevelOuter = bvNone;
	p1->Left = 15;
	p1->Color = 0x00FF7B00;

	TPanel *p2 = new TPanel(Main);
	p2->Parent = FProjects->lab;
	p2->Height = 85;
	p2->Width = 280;
	p2->Top = 640;
	p2->StyleElements >> seClient;
	p2->BevelOuter = bvNone;
	p2->Left = 310;
	p2->Color = 0x00FF7B00;

	TLabel *t1 = new TLabel(Main);
	t1->Parent = p1;
	t1->Left = 15;
	t1->ParentColor = false;
	t1->ParentFont = false;
	t1->StyleElements << seFont;
	t1->Font->Color = clBlack;
	t1->Caption = "R1";
	t1->Font->Size = 50;

	TLabel *di1 = new TLabel(Main);
	di1->Parent = p1;
	di1->Top = 20;
	di1->Left = 110;
	di1->ParentColor = false;
	di1->ParentFont = false;
	di1->StyleElements << seFont;
	di1->Font->Color = clBlack;
	di1->Caption = "������� (��)";
	di1->Font->Size = 10;

	TLabel *dl1 = new TLabel(Main);
	dl1->Parent = p1;
	dl1->Top = 45;
	dl1->Left = 110;
	dl1->ParentColor = false;
	dl1->ParentFont = false;
	dl1->StyleElements << seFont;
	dl1->Font->Color = clBlack;
	dl1->Caption = "������ (��)";
	dl1->Font->Size = 10;

	ed1 = new TEdit(Main);
	ed1->Parent = p1;
	ed1->StyleElements >> seClient >> seFont;
	ed1->Font->Color = clWhite;
	ed1->Color = 0x00DB6A00;
	ed1->Width = 60;
	ed1->Left = 200;
	ed1->Top = 18;
	ed1->OnExit = ed1Exit;
	ed1->OnKeyPress=ed1KeyPress;
	ed1->OnChange=ed1Change;

	ed2 = new TEdit(Main);
	ed2->Parent = p1;
	ed2->StyleElements >> seClient >> seFont;
	ed2->Font->Color = clWhite;
	ed2->Color = 0x00DB6A00;
	ed2->Width = 60;
	ed2->Left = 200;
	ed2->Top = 43;
	ed2->OnExit = ed2Exit;
	ed2->OnKeyPress=ed2KeyPress;
	ed2->OnChange=ed2Change;

	// ----------------------------

	TLabel *t2 = new TLabel(Main);
	t2->Parent = p2;
	t2->Left = 15;
	t2->ParentColor = false;
	t2->ParentFont = false;
	t2->StyleElements << seFont;
	t2->Font->Color = clBlack;
	t2->Caption = "R2";
	t2->Font->Size = 50;

	TLabel *di2 = new TLabel(Main);
	di2->Parent = p2;
	di2->Top = 20;
	di2->Left = 110;
	di2->ParentColor = false;
	di2->ParentFont = false;
	di2->StyleElements << seFont;
	di2->Font->Color = clBlack;
	di2->Caption = "������� (��)";
	di2->Font->Size = 10;

	TLabel *dl2 = new TLabel(Main);
	dl2->Parent = p2;
	dl2->Top = 45;
	dl2->Left = 110;
	dl2->ParentColor = false;
	dl2->ParentFont = false;
	dl2->StyleElements << seFont;
	dl2->Font->Color = clBlack;
	dl2->Caption = "������ (��)";
	dl2->Font->Size = 10;

	ed3 = new TEdit(Main);
	ed3->Parent = p2;
	ed3->StyleElements >> seClient >> seFont;
	ed3->Font->Color = clWhite;
	ed3->Color = 0x00DB6A00;
	ed3->Width = 60;
	ed3->Left = 200;
	ed3->Top = 18;
	ed3->OnExit = ed3Exit;
	ed3->OnKeyPress=ed3KeyPress;
	ed3->OnChange=ed3Change;

	ed4 = new TEdit(Main);
	ed4->Parent = p2;
	ed4->StyleElements >> seClient >> seFont;
	ed4->Font->Color = clWhite;
	ed4->Color = 0x00DB6A00;
	ed4->Width = 60;
	ed4->Left = 200;
	ed4->Top = 43;
	ed4->OnExit = ed4Exit;
	ed4->OnKeyPress=ed4KeyPress;
    ed4->OnChange=ed4Change;

	// ------------------

	B.create(180, 220);
	// �������
	Reost.create(500, 450);
	// ��������
	Res[0].create(485, 220);
	Res[0].r1->Checked=false;
	Res[0].r1->Enabled=false;
	Res[0].r2->Enabled=false;
	Res[0].r3->Enabled=false;
	Res[0].r4->Enabled=false;
	Res[0].r5->Enabled=false;
	Res[0].l_res->Caption="-//-";

	Res[1].create(755, 220);
	Res[1].r1->Checked=false;
	Res[1].r1->Enabled=false;
	Res[1].r2->Enabled=false;
	Res[1].r3->Enabled=false;
	Res[1].r4->Enabled=false;
	Res[1].r5->Enabled=false;
	Res[1].l_res->Caption="-//-";

	// ���������
	A.create(770, 420);
	// ���������
	V[0].create(470, 50);
	V[1].create(745, 50);
	// ����
	P.create(250, 450);
	P.active=false;

	FProjects->lab->Repaint();

	FValue->Width=1045;
	FValue->SG->ColCount=11;
	FValue->SG->Width=1025;

	FValue->SG->Cells[1][0]="U, �";
	FValue->SG->Cells[2][0]="I, �";
	FValue->SG->Cells[3][0]="R1 d, ��";
	FValue->SG->Cells[4][0]="R1 l, ��";
	FValue->SG->Cells[5][0]="R2 d, ��";
	FValue->SG->Cells[6][0]="R2 l, ��";
	FValue->SG->Cells[7][0]="�������� ����. R1, ��";
	FValue->SG->Cells[8][0]="�������� ����. R2, ��";
	FValue->SG->Cells[9][0]="U R1, �";
	FValue->SG->Cells[10][0]="U R2, �";

	for(int i=1;i<=FValue->SG->RowCount;i++)
	{
		for(int j=1;j<=FValue->SG->ColCount;j++)
		{
			FValue->SG->Cells[j][i]="";
		}
	}

	FProjects->lab->Show();
	Lns.paint("r");
	FProjects->Hide();
}

void __fastcall TFProject::im4Click(TObject *Sender)
{
	nlab = 4;
	FProjects->lab = new TMain(Main);
	FProjects->lab->Caption = "������������ ������ �4";

	if(FProjects->memo!=NULL)
	{
		count=1;

		FProjects->memo->Lines->Add("������������ ������ �4");
		FProjects->memo->Lines->Add("����: ������������ ����������� �������������� ������������� ����������� �� �����������");
		FProjects->memo->Lines->Add("����: ����������� ����������� �������������� ������������� ����������� �� �����������");
		FProjects->memo->Lines->Add("------------��� ������-----------");
		FProjects->memo->Lines->SaveToFile(FProjects->SD->FileName);
	}

	temp = 0;

	B.create(170, 200);
	D.create(410, 227);
	Res[0].create(580, 130);
	Res[1].create(580, 270);
	F.create(540, 110, 200, 300);
	T.create(540, 80);
	A.create(820, 350);
	Reost.create(490, 480);
	P.create(220, 480);
	P.active=false;

	TPanel *pt1 = new TPanel(Main);
	pt1->Parent = FProjects->lab;
	pt1->Height = 85;
	pt1->Width = 155;
	pt1->Top = 640;
	pt1->StyleElements >> seClient;
	pt1->BevelOuter = bvNone;
	pt1->Left = 15;
	pt1->Color = 0x00FF7B00;

	TLabel *rt1 = new TLabel(Main);
	rt1->Parent = pt1;
    rt1->Top=8;
	rt1->Left = 15;
	rt1->ParentColor = false;
	rt1->ParentFont = false;
	rt1->StyleElements << seFont;
	rt1->Font->Color = clBlack;
	rt1->Caption = "R1";
	rt1->Font->Size = 20;

	temp1 = new TLabel(Main);
	temp1->Parent = pt1;
	temp1->Top = 8;
	temp1->Left = 70;
	temp1->ParentColor = false;
	temp1->ParentFont = false;
	temp1->StyleElements << seFont;
	temp1->Font->Color = clBlack;
	temp1->Caption = "0\xB0"+s;
	temp1->Font->Size = 20;

	TLabel *rt2 = new TLabel(Main);
	rt2->Parent = pt1;
    rt2->Top=45;
	rt2->Left = 15;
	rt2->ParentColor = false;
	rt2->ParentFont = false;
	rt2->StyleElements << seFont;
	rt2->Font->Color = clBlack;
	rt2->Caption = "R2";
	rt2->Font->Size = 20;

	temp2 = new TLabel(Main);
	temp2->Parent = pt1;
	temp2->Top = 45;
	temp2->Left = 70;
	temp2->ParentColor = false;
	temp2->ParentFont = false;
	temp2->StyleElements << seFont;
	temp2->Font->Color = clBlack;
	temp2->Caption = "0\xB0"+s;
	temp2->Font->Size = 20;

	TPanel *p1 = new TPanel(Main);
	p1->Parent = FProjects->lab;
	p1->Height = 85;
	p1->Width = 350;
	p1->Top = 640;
	p1->StyleElements >> seClient;
	p1->BevelOuter = bvNone;
	p1->Left = 185;
	p1->Color = 0x00FF7B00;

	TPanel *p2 = new TPanel(Main);
	p2->Parent = FProjects->lab;
	p2->Height = 85;
	p2->Width = 350;
	p2->Top = 640;
	p2->StyleElements >> seClient;
	p2->BevelOuter = bvNone;
	p2->Left = 550;
	p2->Color = 0x00FF7B00;

	TLabel *t1 = new TLabel(Main);
	t1->Parent = p1;
	t1->Left = 15;
	t1->ParentColor = false;
	t1->ParentFont = false;
	t1->StyleElements << seFont;
	t1->Font->Color = clBlack;
	t1->Caption = "R1";
	t1->Font->Size = 50;

	R1 = new TLabel(Main);
	R1->Parent = p1;
	R1->Top = 18;
	R1->Left = 125;
	R1->ParentColor = false;
	R1->ParentFont = false;
	R1->StyleElements << seFont;
	R1->Font->Color = clBlack;
	R1->Caption = "1,000 ��";
	R1->Font->Size = 30;

	// ----------------------------

	TLabel *t2 = new TLabel(Main);
	t2->Parent = p2;
	t2->Left = 15;
	t2->ParentColor = false;
	t2->ParentFont = false;
	t2->StyleElements << seFont;
	t2->Font->Color = clBlack;
	t2->Caption = "R2";
	t2->Font->Size = 50;

	R2 = new TLabel(Main);
	R2->Parent = p2;
	R2->Top = 18;
	R2->Left = 125;
	R2->ParentColor = false;
	R2->ParentFont = false;
	R2->StyleElements << seFont;
	R2->Font->Color = clBlack;
	R2->Caption = "1,000 ��";
	R2->Font->Size = 30;

	FProjects->lab->Repaint();

	FValue->Width=950;
	FValue->SG->Width=930;

	FValue->SG->ColCount=10;
	FValue->SG->Cells[1][0]="U, �";
	FValue->SG->Cells[2][0]="R, ��";
	FValue->SG->Cells[3][0]="R1 ��� 0\xB0"+s+", ��";
	FValue->SG->Cells[4][0]="R2 ��� 0\xB0"+s+", ��";
	FValue->SG->Cells[5][0]="����������� R1, \xB0"+s;
	FValue->SG->Cells[6][0]="����������� R2, \xB0"+s;
	FValue->SG->Cells[7][0]="R1, ��";
	FValue->SG->Cells[8][0]="R2, ��";
	FValue->SG->Cells[9][0]="I, �";

	for(int i=1;i<=FValue->SG->RowCount;i++)
	{
		for(int j=1;j<=FValue->SG->ColCount;j++)
		{
			FValue->SG->Cells[j][i]="";
		}
	}

	FProjects->lab->Show();
	Lns.paint("r");
	FProjects->Hide();
}
// ---------------------------------------------------------------------------
void __fastcall TFProject::im5Click(TObject *Sender)
{
	nlab=5;
	FProjects->lab = new TMain(Main);
	FProjects->lab->Caption = "������������ ������ �5";

	if(FProjects->memo!=NULL)
	{
		count=1;

		FProjects->memo->Lines->Add("������������ ������ �5");
		FProjects->memo->Lines->Add("����: ����������� �������������� ������������ � ������� �������������");
		FProjects->memo->Lines->Add("����: ���������� ������������� ������������� � ������� �������������, ����������� ��������������� � �����������.");
		FProjects->memo->Lines->Add("------------��� ������-----------");
		FProjects->memo->Lines->SaveToFile(FProjects->SD->FileName);
	}

	B.create(250,40);
	RLC.create(600,23);
	P.create(300,190);
	D2.create(458,290);
	C.create(450,450);
	P.active=false;

	TPanel *p1 = new TPanel(Main);
	p1->Parent = FProjects->lab;
	p1->Height = 85;
	p1->Width = 410;
	p1->Top = 640;
	p1->StyleElements >> seClient;
	p1->BevelOuter = bvNone;
	p1->Left = 15;
	p1->Color = 0x00FF7B00;

	TPanel *p2 = new TPanel(Main);
	p2->Parent = FProjects->lab;
	p2->Height = 85;
	p2->Width = 470;
	p2->Top = 640;
	p2->StyleElements >> seClient;
	p2->BevelOuter = bvNone;
	p2->Left = 450;
	p2->Color = 0x00FF7B00;

	TLabel *t1 = new TLabel(Main);
	t1->Parent = p1;
	t1->Width=50;
	t1->Left = 15;
    t1->Top=13;
	t1->ParentColor = false;
	t1->ParentFont = false;
	t1->StyleElements << seFont;
	t1->Font->Color = clBlack;
    t1->WordWrap=true;
	t1->Caption = "������� �����������";
	t1->Font->Size = 17;

	TLabel *S = new TLabel(Main);
	S->Parent = p1;
	S->Top = 20;
	S->Left = 170;
	S->ParentColor = false;
	S->ParentFont = false;
	S->StyleElements << seFont;
	S->Font->Color = clBlack;
	S->Caption = "S(��)";
	S->Font->Size = 10;

	TLabel *e1 = new TLabel(Main);
	e1->Parent = p1;
	e1->Top = 45;
	e1->Left = 195;
	e1->ParentColor = false;
	e1->ParentFont = false;
	e1->StyleElements << seFont;
	e1->Font->Color = clBlack;
	e1->Caption = "�";
	e1->Font->Size = 10;

	TLabel *d = new TLabel(Main);
	d->Parent = p1;
	d->Top = 20;
	d->Left = 290;
	d->ParentColor = false;
	d->ParentFont = false;
	d->StyleElements << seFont;
	d->Font->Color = clBlack;
	d->Caption = "d(��)";
	d->Font->Size = 10;

	ed1 = new TEdit(Main);
	ed1->Parent = p1;
	ed1->StyleElements >> seClient >> seFont;
	ed1->Font->Color = clWhite;
	ed1->Color = 0x00DB6A00;
	ed1->Width = 60;
	ed1->Left = 210;
	ed1->Top = 18;
	ed1->OnExit = ed1Exit;
	ed1->OnKeyPress=ed1KeyPress;

	ed2 = new TEdit(Main);
	ed2->Parent = p1;
	ed2->StyleElements >> seClient >> seFont;
	ed2->Font->Color = clWhite;
	ed2->Color = 0x00DB6A00;
	ed2->Width = 60;
	ed2->Left = 210;
	ed2->Top = 43;
	ed2->OnExit = ed2Exit;
	ed2->OnKeyPress=ed2KeyPress;

	ed3 = new TEdit(Main);
	ed3->Parent = p1;
	ed3->StyleElements >> seClient >> seFont;
	ed3->Font->Color = clWhite;
	ed3->Color = 0x00DB6A00;
	ed3->Width = 60;
	ed3->Left = 330;
	ed3->Top = 18;
	ed3->OnExit = ed3Exit;
	ed3->OnKeyPress=ed3KeyPress;

	// ----------------------------

	TLabel *t2 = new TLabel(Main);
	t2->Parent = p2;
	t2->Width=50;
	t2->Left = 15;
	t2->Top=13;
	t2->ParentColor = false;
	t2->ParentFont = false;
	t2->StyleElements << seFont;
	t2->Font->Color = clBlack;
	t2->WordWrap=true;
	t2->Caption = "�������������� �����������";
	t2->Font->Size = 17;

	TLabel *R1 = new TLabel(Main);
	R1->Parent = p2;
	R1->Top = 20;
	R1->Left = 230;
	R1->ParentColor = false;
	R1->ParentFont = false;
	R1->StyleElements << seFont;
	R1->Font->Color = clBlack;
	R1->Caption = "R1(��)";
	R1->Font->Size = 10;

	TLabel *R2 = new TLabel(Main);
	R2->Parent = p2;
	R2->Top = 20;
	R2->Left = 345;
	R2->ParentColor = false;
	R2->ParentFont = false;
	R2->StyleElements << seFont;
	R2->Font->Color = clBlack;
	R2->Caption = "R2(��)";
	R2->Font->Size = 10;

	TLabel *e2= new TLabel(Main);
	e2->Parent = p2;
	e2->Top = 45;
	e2->Left = 260;
	e2->ParentColor = false;
	e2->ParentFont = false;
	e2->StyleElements << seFont;
	e2->Font->Color = clBlack;
	e2->Caption = "�";
	e2->Font->Size = 10;

	TLabel *l= new TLabel(Main);
	l->Parent = p2;
	l->Top = 45;
	l->Left = 350;
	l->ParentColor = false;
	l->ParentFont = false;
	l->StyleElements << seFont;
	l->Font->Color = clBlack;
	l->Caption = "L (��)";
	l->Font->Size = 10;

	ed4 = new TEdit(Main);
	ed4->Parent = p2;
	ed4->StyleElements >> seClient >> seFont;
	ed4->Font->Color = clWhite;
	ed4->Color = 0x00DB6A00;
	ed4->Width = 60;
	ed4->Left = 275;
	ed4->Top = 18;
	ed4->OnExit = ed4Exit;
	ed4->OnKeyPress=ed4KeyPress;

	ed5 = new TEdit(Main);
	ed5->Parent = p2;
	ed5->StyleElements >> seClient >> seFont;
	ed5->Font->Color = clWhite;
	ed5->Color = 0x00DB6A00;
	ed5->Width = 60;
	ed5->Left = 275;
	ed5->Top = 43;
	ed5->OnExit = ed5Exit;
	ed5->OnKeyPress=ed5KeyPress;

	ed6 = new TEdit(Main);
	ed6->Parent = p2;
	ed6->StyleElements >> seClient >> seFont;
	ed6->Font->Color = clWhite;
	ed6->Color = 0x00DB6A00;
	ed6->Width = 60;
	ed6->Left = 390;
	ed6->Top = 18;
	ed6->OnExit = ed6Exit;
	ed6->OnKeyPress=ed6KeyPress;

	ed7 = new TEdit(Main);
	ed7->Parent = p2;
	ed7->StyleElements >> seClient >> seFont;
	ed7->Font->Color = clWhite;
	ed7->Color = 0x00DB6A00;
	ed7->Width = 60;
	ed7->Left = 390;
	ed7->Top = 43;
	ed7->OnExit = ed7Exit;
	ed7->OnKeyPress=ed7KeyPress;

	FValue->Width=1250;
	FValue->SG->Width=1230;
	FValue->SG->Height=169;
	FValue->SG->DefaultColWidth=105;
	FValue->SG->ColCount=12;
    FValue->SG->RowCount=6;
	FValue->SG->Cells[1][0]="��� ������������";
	FValue->SG->Cells[2][0]="���-��";
	FValue->SG->Cells[3][0]="��� �����������";
	FValue->SG->Cells[4][0]="E";
	FValue->SG->Cells[5][0]="S, ��";
	FValue->SG->Cells[6][0]="d, ��";
	FValue->SG->Cells[7][0]="R1, ��";
	FValue->SG->Cells[8][0]="R2, ��";
	FValue->SG->Cells[9][0]="l, ��";
	FValue->SG->Cells[10][0]="�, ��";
	FValue->SG->Cells[11][0]="q, ���";

	for(int i=1;i<=FValue->SG->RowCount;i++)
	{
		for(int j=1;j<=FValue->SG->ColCount;j++)
		{
			FValue->SG->Cells[j][i]="";
		}
	}

	FProjects->lab->Show();
	Lns.paint("r");
	FProjects->Hide();
}
//---------------------------------------------------------------------------

void __fastcall TFProject::im7Click(TObject *Sender)
{
	nlab=6;
	FProjects->lab = new TMain(Main);
	FProjects->lab->Caption = "������������ ������ �6";

	if(FProjects->memo!=NULL)
	{
		count=1;

		FProjects->memo->Lines->Add("������������ ������ �6");
		FProjects->memo->Lines->Add("����: ��������� ��� � ����������� ������������� ��������� ����������� ����");
		FProjects->memo->Lines->Add("����: �������� ��� � ���������� ������������� ����������� ��������� ����.");
		FProjects->memo->Lines->Add("------------��� ������-----------");
		FProjects->memo->Lines->Add(IntToStr(count)+". ��� ���������� ����������� ������������� � ��� ��������� ��������� �������� ���������� � ���� ���� ���� ");
		count++;
		FProjects->memo->Lines->SaveToFile(FProjects->SD->FileName);
	}

	sg1=new TStringGrid(FProjects->lab);
	sg1->Parent=FProjects->lab;

	sg2=new TStringGrid(FProjects->lab);
	sg2->Parent=FProjects->lab;

	b1=new TBitBtn(FProjects->lab);
	b1->Parent=FProjects->lab;
	b2=new TBitBtn(FProjects->lab);
	b2->Parent=FProjects->lab;

    TPanel *p1 = new TPanel(Main);
	p1->Parent = FProjects->lab;

	TLabel *t1 = new TLabel(Main);
	t1->Parent = p1;

	TLabel *t2 = new TLabel(Main);
	t2->Parent = p1;

	Ei = new TLabel(Main);
	Ei->Parent = p1;

	sg1->FixedCols=0;
	sg1->FixedRows=0;
	sg1->ColCount=4;
	sg1->RowCount=3;
	sg1->BevelOuter=bvNone;
	sg1->Left=10;
	sg1->Top=650;
	sg1->Width=265;
	sg1->Height=80;
	sg1->Cells[0][0]="� �����";
	sg1->Cells[1][0]="U, B";
	sg1->Cells[2][0]="R, ��";
	sg1->Cells[3][0]="I, A";
	sg1->Cells[0][1]="1";
	sg1->Cells[0][2]="2";

	b1->Top=650;
	b1->Left=285;
	b1->Kind=bkOK;
	b1->Width=40;
	b1->Height=80;
	b1->Caption="";
	b1->OnClick=b1Click;

	b2->Top=645;
	b2->Left=970;
	b2->Kind=bkRetry;
	b2->Width=40;
	b2->Height=80;
	b2->Caption="";
	b2->OnClick=b2Click;

	sg2->FixedCols=0;
	sg2->FixedRows=0;
	sg2->ColCount=2;
	sg2->RowCount=3;
	sg2->BevelOuter=bvNone;
	sg2->Left=335;
	sg2->Top=650;
	sg2->Width=135;
	sg2->Height=80;
	sg2->Cells[0][0]="��������";
	sg2->Cells[1][0]="��������";
	sg2->Cells[0][1]="r";
	sg2->Cells[0][2]="���";

	p1->Height = 90;
	p1->Width = 480;
	p1->Top =640;
	p1->StyleElements >> seClient;
	p1->BevelOuter = bvNone;
	p1->Left = 480;
	p1->Color = 0x00FF7B00;

    t1->Top=5;
	t1->Left = 20;
	t1->ParentColor = false;
	t1->ParentFont = false;
	t1->StyleElements << seFont;
	t1->Font->Color = clBlack;
	t1->Caption = "���";
	t1->Font->Size = 50;

	t2->Top=59;
	t2->Left = 155;
	t2->ParentColor = false;
	t2->ParentFont = false;
	t2->StyleElements << seFont;
	t2->Font->Color = clBlack;
	t2->Caption = "���.����";
	t2->Font->Size = 10;

	Ei = new TLabel(Main);
	Ei->Parent = p1;
	Ei->Top = 18;
	Ei->Left = 240;
	Ei->ParentColor = false;
	Ei->ParentFont = false;
	Ei->StyleElements << seFont;
	Ei->Font->Color = clBlack;
	Ei->Caption = "-//- �";
	Ei->Font->Size = 35;

	B.create(500,100);
	A.create(760,250);
	Reost.create(550,400);
	P.create(330,400);
	P.active=false;

	FValue->Width=370;
	FValue->SG->Width=350;
	FValue->SG->Height=100;

	FValue->SG->ColCount=4;
    FValue->SG->RowCount=3;
	FValue->SG->Cells[1][0]="U, �";
	FValue->SG->Cells[2][0]="R, ��";
	FValue->SG->Cells[3][0]="I, �";

	FValue->SG2=new TStringGrid(FValue);
	FValue->SG2->Parent=FValue;
	FValue->SG2->Top=115;
	FValue->SG2->Left=8;
	FValue->SG2->Height=80;
    FValue->SG2->Width=135;
	FValue->SG2->FixedCols=0;
	FValue->SG2->FixedRows=0;
	FValue->SG2->ColCount=2;
	FValue->SG2->RowCount=3;
	FValue->SG2->Cells[0][1]="r";
	FValue->SG2->Cells[0][2]="���";
	FValue->SG2->Cells[1][0]="��������";
	FValue->SG2->Cells[2][0]="��������";

	FValue->Height=282;

    for(int i=1;i<=FValue->SG->RowCount;i++)
	{
		for(int j=1;j<=FValue->SG->ColCount;j++)
		{
			FValue->SG->Cells[j][i]="";
		}
	}

	FProjects->lab->Show();
	Lns.paint("r");
	FProjects->Hide();
}
//---------------------------------------------------------------------------

void __fastcall TFProject::im8Click(TObject *Sender)
{
	nlab=7;
	FProjects->lab = new TMain(Main);
	FProjects->lab->Caption = "������������ ������ �7";

	if(FProjects->memo!=NULL)
	{
		count=1;

		FProjects->memo->Lines->Add("������������ ������ �7");
		FProjects->memo->Lines->Add("����: ������������ ����������� ��������� �������� ��������� ��� �� ���� ����");
		FProjects->memo->Lines->Add("����: ����������� ����������� ������������ ��������� �������� ��������� ��� �� ���� ���� I.");
		FProjects->memo->Lines->Add("------------��� ������-----------");
		FProjects->memo->Lines->SaveToFile(FProjects->SD->FileName);
	}

	TPanel *p=new TPanel(FProjects->lab);
	p->Parent=FProjects->lab;

    TPanel *p1 = new TPanel(Main);
	p1->Parent = FProjects->lab;

	TPanel *p2 = new TPanel(Main);
	p2->Parent = FProjects->lab;

	TLabel *t1 = new TLabel(Main);
	t1->Parent = p1;
	TLabel *t2 = new TLabel(Main);
	t2->Parent = p1;

	TLabel *t3 = new TLabel(Main);
	t3->Parent = p2;
	TLabel *t4 = new TLabel(Main);
	t4->Parent = p2;

	ch1 = new TCheckBox(FProjects->lab);
	ch1->Parent=FProjects->lab;

	ch2 = new TCheckBox(FProjects->lab);
	ch2->Parent=FProjects->lab;

	b3=new TBitBtn(FProjects->lab);
	b3->Parent=FProjects->lab;

	b4=new TBitBtn(FProjects->lab);
	b4->Parent=FProjects->lab;

	TLabel *l1=new TLabel(FProjects->lab);
	l1->Parent=p;
	TLabel *l2=new TLabel(FProjects->lab);
	l2->Parent=p;

    p->StyleElements>>seClient;
	p->Color=0x00181818;
	p->Top=640;
	p->Left=36;
	p->Height=80;
    p->BevelOuter=bvNone;

	ch1->Left=15;
	ch1->Top=655;
	ch1->Width=16;
	ch1->OnClick=ch1Click;
	ch1->Enabled=false;
	ch2->Left=15;
	ch2->Top=682;
	ch2->Width=16;
	ch2->OnClick=ch2Click;
    ch2->Enabled=false;

	b3->Top=709;
	b3->Left=15;
	b3->Kind=bkOK;
	b3->Width=80;
	b3->Height=25;
	b3->Caption="";
	b3->OnClick=b3Click;

	b4->Top=650;
	b4->Left=1055;
	b4->Kind=bkRetry;
	b4->Width=40;
	b4->Height=80;
	b4->Caption="";
	b4->OnClick=b4Click;

	l1->Top=16;
	l1->Left=3;
	l1->Caption="1-�� ����";

	l2->Top=44;
	l2->Left=3;
	l2->Caption="2-�� ����";

    p1->Height = 95;
	p1->Width = 460;
	p1->Top = 640;
	p1->StyleElements >> seClient;
	p1->BevelOuter = bvNone;
	p1->Left = 115;
	p1->Color = 0x00FF7B00;

	t1->Top=7;
	t1->Left = 20;
	t1->ParentColor = false;
	t1->ParentFont = false;
	t1->StyleElements << seFont;
	t1->Font->Color = clBlack;
	t1->Caption = "���";
	t1->Font->Size = 50;

	t2->Top=61;
	t2->Left = 155;
	t2->ParentColor = false;
	t2->ParentFont = false;
	t2->StyleElements << seFont;
	t2->Font->Color = clBlack;
	t2->Caption = "���.����";
	t2->Font->Size = 10;

	Ei = new TLabel(Main);
	Ei->Parent = p1;
	Ei->Top = 20;
	Ei->Left = 230;
	Ei->ParentColor = false;
	Ei->ParentFont = false;
	Ei->StyleElements << seFont;
	Ei->Font->Color = clBlack;
	Ei->Caption = "-//- �";
	Ei->Font->Size = 35;

	p2->Height = 95;
	p2->Width = 455;
	p2->Top = 640;
	p2->StyleElements >> seClient;
	p2->BevelOuter = bvNone;
	p2->Left = 590;
	p2->Color = 0x00FF7B00;

	t3->Top=7;
	t3->Left = 15;
	t3->ParentColor = false;
	t3->ParentFont = false;
	t3->StyleElements << seFont;
	t3->Font->Color = clBlack;
	t3->Caption = "���";
	t3->Font->Size = 50;

	t4->Top=61;
	t4->Left = 150;
	t4->ParentColor = false;
	t4->ParentFont = false;
	t4->StyleElements << seFont;
	t4->Font->Color = clBlack;
	t4->Caption = "���.����";
	t4->Font->Size = 10;

	kpd = new TLabel(Main);
	kpd->Parent = p2;
	kpd->Top = 20;
	kpd->Left = 230;
	kpd->ParentColor = false;
	kpd->ParentFont = false;
	kpd->StyleElements << seFont;
	kpd->Font->Color = clBlack;
	kpd->Caption = "-//- %";
	kpd->Font->Size = 35;

	B.create(500,100);
	A.create(760,250);
	Reost.create(550,400);
	P.create(330,400);
	P.active=false;

	FValue->SG->ColCount=6;
	FValue->SG->RowCount=6;
	FValue->Width=560;
	FValue->SG->Width=540;
	FValue->SG->Cells[1][0]="U, �";
	FValue->SG->Cells[2][0]="R, ��";
	FValue->SG->Cells[3][0]="I, �";
	FValue->SG->Cells[4][0]="���, �";
	FValue->SG->Cells[5][0]="���, %";

    for(int i=1;i<=FValue->SG->RowCount;i++)
	{
		for(int j=1;j<=FValue->SG->ColCount;j++)
		{
			FValue->SG->Cells[j][i]="";
		}
	}

	FProjects->lab->Show();
	Lns.paint("r");
	FProjects->Hide();

	MessageDlg("��� ���������� ��� ��������� ����, ��� ���������� ����� ��� ���������� �������������\n��� ����� ��������� 2 �����, ��� ���������� �������� ����������� � ������ ����� ���� �����", mtInformation, TMsgDlgButtons()<<mbOK,0);
}
//---------------------------------------------------------------------------
void __fastcall TFProject::ed1Exit(TObject *Sender)
{
	if(nlab==3)
	{
		if(ed1->Text=="")
		{
			//---
		}
		else
		{
			Res[0].d = StrToFloat(ed1->Text);
		}
	}
	else if(nlab==5)
	{
		if(ed1->Text=="")
		{
			//---
		}
		else
		{
			if(FProjects->memo!=NULL)
			{
				FProjects->memo->Lines->Add(IntToStr(count)+". ��� �������� ������������ ��������� S ������� ������ "+ed1->Text+" ��");
				count++;
				FProjects->memo->Lines->SaveToFile(FProjects->SD->FileName);
			}
			Sk=StrToFloat(ed1->Text);
		}
	}
}

void __fastcall TFProject::ed2Exit(TObject *Sender)
{
	if(nlab==3)
	{
		if(ed2->Text=="")
		{
			//---
		}
		else
		{
			Res[0].l = StrToFloat(ed2->Text);
		}
	}
	else if(nlab==5)
	{
		if(ed2->Text=="")
		{
			//---
		}
		else
		{
            if(FProjects->memo!=NULL)
			{
				FProjects->memo->Lines->Add(IntToStr(count)+". ��� �������� ������������ ��������� �������� ��������������� ������������� ��� ����������� ������ "+ed2->Text+" ��");
				count++;
				FProjects->memo->Lines->SaveToFile(FProjects->SD->FileName);
			}
			Ek=StrToFloat(ed2->Text);
		}
	}
}

void __fastcall TFProject::ed3Exit(TObject *Sender)
{
	if(nlab==3)
	{
		if(ed3->Text=="")
		{
			//---
		}
		else
		{
			Res[1].d = StrToFloat(ed3->Text);
		}
	}
	else if(nlab==5)
	{
		if(ed3->Text=="")
		{
			//---
		}
		else
		{
            if(FProjects->memo!=NULL)
			{
				FProjects->memo->Lines->Add(IntToStr(count)+". ��� �������� ������������ ��������� ��������� ����� ���������� (d) ������� ������ "+ed3->Text+" ��");
				count++;
				FProjects->memo->Lines->SaveToFile(FProjects->SD->FileName);
			}
			dk=StrToFloat(ed3->Text);
		}
	}
}

void __fastcall TFProject::ed4Exit(TObject *Sender)
{
	if(nlab==3)
	{
		if(ed4->Text=="")
		{
			//---
		}
		else
		{
			Res[1].l = StrToFloat(ed4->Text);
		}
	}
	else if(nlab==5)
	{
		if(ed4->Text=="")
		{
			//---
		}
		else
		{
			if(FProjects->memo!=NULL)
			{
				FProjects->memo->Lines->Add(IntToStr(count)+". ��� ��������������� ������������ ��������� ���������� ������ ������ "+ed4->Text+" ��");
				count++;
				FProjects->memo->Lines->SaveToFile(FProjects->SD->FileName);
			}
			R1k=StrToFloat(ed4->Text);
		}
	}
}

void __fastcall TFProject::ed5Exit(TObject *Sender)
{
	if(ed5->Text=="")
	{
		//---
	}
	else
	{
		if(FProjects->memo!=NULL)
		{
			FProjects->memo->Lines->Add(IntToStr(count)+". ��� ��������������� ������������ ��������� �������� ��������������� ������������� ����������� ������� "+ed5->Text);
			count++;
			FProjects->memo->Lines->SaveToFile(FProjects->SD->FileName);
		}
		Ek=StrToFloat(ed5->Text);
	}
}

void __fastcall TFProject::ed6Exit(TObject *Sender)
{
	if(ed6->Text=="")
	{
		//---
	}
	else
	{
		if(FProjects->memo!=NULL)
		{
			FProjects->memo->Lines->Add(IntToStr(count)+". ��� ��������������� ������������ ��������� ������� ������ ������ "+ed6->Text+" ��");
			count++;
			FProjects->memo->Lines->SaveToFile(FProjects->SD->FileName);
		}
		R2k=StrToFloat(ed6->Text);
	}
}

void __fastcall TFProject::ed7Exit(TObject *Sender)
{
	if(ed7->Text=="")
	{
		//---
	}
	else
	{
        if(FProjects->memo!=NULL)
		{
			FProjects->memo->Lines->Add(IntToStr(count)+". ����� ��������� ������ ��������������� ������������ ������ "+ed7->Text+" ��");
			count++;
			FProjects->memo->Lines->SaveToFile(FProjects->SD->FileName);
		}
		lk=StrToFloat(ed7->Text);
	}
}

void __fastcall TFProject::ed1KeyPress(TObject *Sender, System::WideChar &Key)
{
    if((Key!=VK_BACK)&&(Key<'0'||Key>'9')&&(Key!=','))Key=0;
}
void __fastcall TFProject::ed2KeyPress(TObject *Sender, System::WideChar &Key)
{
	if((Key!=VK_BACK)&&(Key<'0'||Key>'9')&&(Key!=','))Key=0;
}
void __fastcall TFProject::ed3KeyPress(TObject *Sender, System::WideChar &Key)
{
	if((Key!=VK_BACK)&&(Key<'0'||Key>'9')&&(Key!=','))Key=0;
}
void __fastcall TFProject::ed4KeyPress(TObject *Sender, System::WideChar &Key)
{
	if((Key!=VK_BACK)&&(Key<'0'||Key>'9')&&(Key!=','))Key=0;
}
void __fastcall TFProject::ed5KeyPress(TObject *Sender, System::WideChar &Key)
{
	if((Key!=VK_BACK)&&(Key<'0'||Key>'9')&&(Key!=','))Key=0;
}
void __fastcall TFProject::ed6KeyPress(TObject *Sender, System::WideChar &Key)
{
	if((Key!=VK_BACK)&&(Key<'0'||Key>'9')&&(Key!=','))Key=0;
}
void __fastcall TFProject::ed7KeyPress(TObject *Sender, System::WideChar &Key)
{
	if((Key!=VK_BACK)&&(Key<'0'||Key>'9')&&(Key!=','))Key=0;
}

void __fastcall TFProject::ed1Change(TObject *Sender)
{
    if(P.active==true)
	{
		ShowMessage("������ ��� ������ ��������, ���������� ����");
	}
}
void __fastcall TFProject::ed2Change(TObject *Sender)
{
	if(P.active==true)
	{
		ShowMessage("������ ��� ������ ��������, ���������� ����");
	}
}
void __fastcall TFProject::ed3Change(TObject *Sender)
{
	if(P.active==true)
	{
		ShowMessage("������ ��� ������ ��������, ���������� ����");
	}
}
void __fastcall TFProject::ed4Change(TObject *Sender)
{
	if(P.active==true)
	{
		ShowMessage("������ ��� ������ ��������, ���������� ����");
	}
}

int numOp=0;
void __fastcall TFProject::b1Click(TObject *Sender)
{
	numOp++;
	if(numOp==1)
	{
		if(FProjects->memo!=NULL)
		{
			FProjects->memo->Lines->Add(IntToStr(count)+". � 1-�� ����� ��������� ���������� ��������� ���� "+FloatToStr(B.Volt)+" � � ������������� �������� "+FloatToStr(Reost.R)+" ��");
			count++;
			FProjects->memo->Lines->Add(IntToStr(count)+". ����� ������� ���� ���� � ���� ��� ������� ����� "+A.l->Caption+" A");
			count++;
			FProjects->memo->Lines->SaveToFile(FProjects->SD->FileName);
		}
		sg1->Cells[1][1]=FloatToStr(B.Volt);
		sg1->Cells[2][1]=FloatToStr(Reost.R);
		sg1->Cells[3][1]=A.l->Caption;
	}
	else if(numOp==2)
	{
		if((sg1->Cells[1][1]==FloatToStr(B.Volt)) && (sg1->Cells[2][1]==FloatToStr(Reost.R)))
		{
			ShowMessage("�������� �������� 1-�� � 2-�� ����� �� ������ ���������");
			numOp--;
		}
		else
		{
			if(FProjects->memo!=NULL)
			{
				FProjects->memo->Lines->Add(IntToStr(count)+". �� 2-�� ����� ��������� ���������� ��������� ���� "+FloatToStr(B.Volt)+" � � ������������� �������� "+FloatToStr(Reost.R)+" ��");
				count++;
				FProjects->memo->Lines->Add(IntToStr(count)+". ����� ������� ���� ���� � ���� ��� ������� ����� "+A.l->Caption+" A");
				count++;
				FProjects->memo->Lines->SaveToFile(FProjects->SD->FileName);
			}
			sg1->Cells[1][2]=FloatToStr(B.Volt);
			sg1->Cells[2][2]=FloatToStr(Reost.R);
			sg1->Cells[3][2]=A.l->Caption;

			float r=((StrToFloat(sg1->Cells[1][1]))-(StrToFloat(sg1->Cells[1][2])))/((StrToFloat(sg1->Cells[3][2]))-(StrToFloat(sg1->Cells[3][1])));

			float E=(StrToFloat(sg1->Cells[3][1]))*(StrToFloat(sg1->Cells[2][1])+r);
			sg2->Cells[1][1]=FloatToStrF(r,ffFixed,9,5);
			sg2->Cells[1][2]=FloatToStrF(E,ffFixed,9,5);
			Ei->Caption=FloatToStrF(E,ffFixed,9,3)+" �";
			b1->Enabled=false;

			if(FProjects->memo!=NULL)
			{
				FProjects->memo->Lines->Add(IntToStr(count)+". ����� ���������� ���� ������ �� ���������� ����������� ���� ��������� ���������� ������������� ��������� ���� � ���");
				count++;
				FProjects->memo->Lines->Add(IntToStr(count)+". ��������� ������������� ��������� ����  "+FloatToStrF(r,ffFixed,9,5)+" ��");
				count++;
				FProjects->memo->Lines->Add(IntToStr(count)+". ��� ������������� ��������� ����  "+FloatToStrF(E,ffFixed,9,5)+" �");
				count++;
				FProjects->memo->Lines->SaveToFile(FProjects->SD->FileName);
			}
		}
	}
}
void __fastcall TFProject::b2Click(TObject *Sender)
{
	if(FProjects->memo!=NULL)
	{
		FProjects->memo->Lines->Add(IntToStr(count)+". ��� ���������� ����� �������� ������� ������������� ��������");
		count++;
		FProjects->memo->Lines->SaveToFile(FProjects->SD->FileName);
	}
	numOp=0;
	for(int i=1;i<5;i++)
	{
		for(int j=1;j<3;j++)
		{
            sg1->Cells[i][j]="";
		}
	}
	sg2->Cells[1][1]="";
	sg2->Cells[1][2]="";
	Ei->Caption="-//- �";
	b1->Enabled=true;
}

void __fastcall TFProject::b3Click(TObject *Sender)
{
	numOp++;
	if(numOp==1)
	{
        if(FProjects->memo!=NULL)
		{
			FProjects->memo->Lines->Add(IntToStr(count)+". � 1-�� ����� ��������� ���������� ��������� ���� "+FloatToStr(B.Volt)+" � � ������������� �������� "+FloatToStr(Reost.R)+" ��");
			count++;
			FProjects->memo->Lines->Add(IntToStr(count)+". ����� ������� ���� ���� � ���� ��� ������� ����� "+A.l->Caption+" A");
			count++;
			FProjects->memo->Lines->SaveToFile(FProjects->SD->FileName);
		}
		ch1->Enabled=true;
		ch1->Checked=true;
		u1_7=B.Volt;
		r1_7=Reost.R;
		i1_7=u1_7/r1_7;
	}
	else if(numOp==2)
	{
		u2_7=B.Volt;
		r2_7=Reost.R;
		i2_7=u2_7/r2_7;
		r_7=(u1_7-u2_7)/(i2_7-i1_7);
		Ei_7=i1_7*(r1_7+r_7);
		Ei->Caption=FloatToStrF(Ei_7,ffFixed,9,3)+" �";
		FProjects->kpd->Caption=FloatToStrF((Ei_7/B.Volt)*100,ffFixed,9,2)+" %";
		ch2->Enabled=true;
		ch2->Checked=true;
		b3->Enabled=false;
		go=true;
		if(FProjects->memo!=NULL)
		{
			FProjects->memo->Lines->Add(IntToStr(count)+". �� 2-�� ����� ��������� ���������� ��������� ���� "+FloatToStr(B.Volt)+" � � ������������� �������� "+FloatToStr(Reost.R)+" ��");
			count++;
			FProjects->memo->Lines->Add(IntToStr(count)+". ����� ������� ���� ���� � ���� ��� ������� ����� "+A.l->Caption+" A");
			count++;
			FProjects->memo->Lines->Add(IntToStr(count)+". ����� ���������� ���� ������ �� ���������� ����������� ���� ��������� ���������� ������������� ��������� ���� � ���");
			count++;
			FProjects->memo->Lines->Add(IntToStr(count)+". ��� ��������� ����  "+FloatToStrF(Ei_7,ffFixed,9,3)+" �");
			count++;
			FProjects->memo->Lines->Add(IntToStr(count)+". ����� ����������� ��� ��������� ���� ���� ������������ ��� ���: "+FloatToStrF((Ei_7/B.Volt)*100,ffFixed,9,2)+" % ��� ���������� "+FloatToStr(B.Volt)+" �");
			count++;
			FProjects->memo->Lines->SaveToFile(FProjects->SD->FileName);
		}
	}
}

void __fastcall TFProject::b4Click(TObject *Sender)
{
    numOp=0;
    if(FProjects->memo!=NULL)
	{
		FProjects->memo->Lines->Add(IntToStr(count)+". ��� ���������� ����� �������� ������� ������������� ��������");
		count++;
		FProjects->memo->Lines->SaveToFile(FProjects->SD->FileName);
	}
	b3->Enabled=true;
	ch1->Enabled=false;
	ch1->Checked=false;
	ch2->Enabled=false;
	ch2->Checked=false;
	u1_7=0;
	u2_7=0;
	r1_7=0;
	r2_7=0;
	i1_7=0;
	i2_7=0;
	r_7=0;
	Ei_7=0;
	Ei->Caption="-//- �";
	kpd->Caption="-//- %";
}

void __fastcall TFProject::ch1Click(TObject *Sender)
{
	if(ch1->Checked==true)
	{
		ch1->Checked=true;
	}
}
void __fastcall TFProject::ch2Click(TObject *Sender)
{
	if(ch2->Checked==true)
	{
		ch2->Checked==true;
	}
	else if(ch2->Checked==false)
	{
		ch2->Checked==false;
	}
}
                                  */
