﻿'------------------------------------------------------------------------------
' <auto-generated>
'     This code was generated by a tool.
'     Runtime Version:4.0.30319.42000
'
'     Changes to this file may cause incorrect behavior and will be lost if
'     the code is regenerated.
' </auto-generated>
'------------------------------------------------------------------------------

Option Strict Off
Option Explicit On

Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.ReportSource
Imports CrystalDecisions.Shared
Imports System
Imports System.ComponentModel


Public Class RPT_IJSMR
    Inherits ReportClass
    
    Public Sub New()
        MyBase.New
    End Sub
    
    Public Overrides Property ResourceName() As String
        Get
            Return "RPT_IJSMR.rpt"
        End Get
        Set
            'Do nothing
        End Set
    End Property
    
    Public Overrides Property NewGenerator() As Boolean
        Get
            Return true
        End Get
        Set
            'Do nothing
        End Set
    End Property
    
    Public Overrides Property FullResourceName() As String
        Get
            Return "LMIS.RPT_IJSMR.rpt"
        End Get
        Set
            'Do nothing
        End Set
    End Property
    
    <Browsable(false),  _
     DesignerSerializationVisibilityAttribute(System.ComponentModel.DesignerSerializationVisibility.Hidden)>  _
    Public ReadOnly Property Section1() As CrystalDecisions.CrystalReports.Engine.Section
        Get
            Return Me.ReportDefinition.Sections(0)
        End Get
    End Property
    
    <Browsable(false),  _
     DesignerSerializationVisibilityAttribute(System.ComponentModel.DesignerSerializationVisibility.Hidden)>  _
    Public ReadOnly Property Section2() As CrystalDecisions.CrystalReports.Engine.Section
        Get
            Return Me.ReportDefinition.Sections(1)
        End Get
    End Property
    
    <Browsable(false),  _
     DesignerSerializationVisibilityAttribute(System.ComponentModel.DesignerSerializationVisibility.Hidden)>  _
    Public ReadOnly Property GroupHeaderSection1() As CrystalDecisions.CrystalReports.Engine.Section
        Get
            Return Me.ReportDefinition.Sections(2)
        End Get
    End Property
    
    <Browsable(false),  _
     DesignerSerializationVisibilityAttribute(System.ComponentModel.DesignerSerializationVisibility.Hidden)>  _
    Public ReadOnly Property Section3() As CrystalDecisions.CrystalReports.Engine.Section
        Get
            Return Me.ReportDefinition.Sections(3)
        End Get
    End Property
    
    <Browsable(false),  _
     DesignerSerializationVisibilityAttribute(System.ComponentModel.DesignerSerializationVisibility.Hidden)>  _
    Public ReadOnly Property GroupFooterSection1() As CrystalDecisions.CrystalReports.Engine.Section
        Get
            Return Me.ReportDefinition.Sections(4)
        End Get
    End Property
    
    <Browsable(false),  _
     DesignerSerializationVisibilityAttribute(System.ComponentModel.DesignerSerializationVisibility.Hidden)>  _
    Public ReadOnly Property Section4() As CrystalDecisions.CrystalReports.Engine.Section
        Get
            Return Me.ReportDefinition.Sections(5)
        End Get
    End Property
    
    <Browsable(false),  _
     DesignerSerializationVisibilityAttribute(System.ComponentModel.DesignerSerializationVisibility.Hidden)>  _
    Public ReadOnly Property Section5() As CrystalDecisions.CrystalReports.Engine.Section
        Get
            Return Me.ReportDefinition.Sections(6)
        End Get
    End Property
    
    <Browsable(false),  _
     DesignerSerializationVisibilityAttribute(System.ComponentModel.DesignerSerializationVisibility.Hidden)>  _
    Public ReadOnly Property Parameter_Title() As CrystalDecisions.[Shared].IParameterField
        Get
            Return Me.DataDefinition.ParameterFields(0)
        End Get
    End Property
    
    <Browsable(false),  _
     DesignerSerializationVisibilityAttribute(System.ComponentModel.DesignerSerializationVisibility.Hidden)>  _
    Public ReadOnly Property Parameter_RefNo() As CrystalDecisions.[Shared].IParameterField
        Get
            Return Me.DataDefinition.ParameterFields(1)
        End Get
    End Property
    
    <Browsable(false),  _
     DesignerSerializationVisibilityAttribute(System.ComponentModel.DesignerSerializationVisibility.Hidden)>  _
    Public ReadOnly Property Parameter_DepartmentID() As CrystalDecisions.[Shared].IParameterField
        Get
            Return Me.DataDefinition.ParameterFields(2)
        End Get
    End Property
    
    <Browsable(false),  _
     DesignerSerializationVisibilityAttribute(System.ComponentModel.DesignerSerializationVisibility.Hidden)>  _
    Public ReadOnly Property Parameter_FromDate() As CrystalDecisions.[Shared].IParameterField
        Get
            Return Me.DataDefinition.ParameterFields(3)
        End Get
    End Property
    
    <Browsable(false),  _
     DesignerSerializationVisibilityAttribute(System.ComponentModel.DesignerSerializationVisibility.Hidden)>  _
    Public ReadOnly Property Parameter_ToDate() As CrystalDecisions.[Shared].IParameterField
        Get
            Return Me.DataDefinition.ParameterFields(4)
        End Get
    End Property
    
    <Browsable(false),  _
     DesignerSerializationVisibilityAttribute(System.ComponentModel.DesignerSerializationVisibility.Hidden)>  _
    Public ReadOnly Property Parameter_CustomTitle() As CrystalDecisions.[Shared].IParameterField
        Get
            Return Me.DataDefinition.ParameterFields(5)
        End Get
    End Property
    
    <Browsable(false),  _
     DesignerSerializationVisibilityAttribute(System.ComponentModel.DesignerSerializationVisibility.Hidden)>  _
    Public ReadOnly Property Parameter_ItemID() As CrystalDecisions.[Shared].IParameterField
        Get
            Return Me.DataDefinition.ParameterFields(6)
        End Get
    End Property
    
    <Browsable(false),  _
     DesignerSerializationVisibilityAttribute(System.ComponentModel.DesignerSerializationVisibility.Hidden)>  _
    Public ReadOnly Property Parameter_ItemCategory() As CrystalDecisions.[Shared].IParameterField
        Get
            Return Me.DataDefinition.ParameterFields(7)
        End Get
    End Property
    
    <Browsable(false),  _
     DesignerSerializationVisibilityAttribute(System.ComponentModel.DesignerSerializationVisibility.Hidden)>  _
    Public ReadOnly Property Parameter_WithDateRange() As CrystalDecisions.[Shared].IParameterField
        Get
            Return Me.DataDefinition.ParameterFields(8)
        End Get
    End Property
    
    <Browsable(false),  _
     DesignerSerializationVisibilityAttribute(System.ComponentModel.DesignerSerializationVisibility.Hidden)>  _
    Public ReadOnly Property Parameter_ItemSubclassification() As CrystalDecisions.[Shared].IParameterField
        Get
            Return Me.DataDefinition.ParameterFields(9)
        End Get
    End Property
    
    <Browsable(false),  _
     DesignerSerializationVisibilityAttribute(System.ComponentModel.DesignerSerializationVisibility.Hidden)>  _
    Public ReadOnly Property Parameter_ItemClassification() As CrystalDecisions.[Shared].IParameterField
        Get
            Return Me.DataDefinition.ParameterFields(10)
        End Get
    End Property
    
    <Browsable(false),  _
     DesignerSerializationVisibilityAttribute(System.ComponentModel.DesignerSerializationVisibility.Hidden)>  _
    Public ReadOnly Property Parameter_IJTypeID() As CrystalDecisions.[Shared].IParameterField
        Get
            Return Me.DataDefinition.ParameterFields(11)
        End Get
    End Property
    
    <Browsable(false),  _
     DesignerSerializationVisibilityAttribute(System.ComponentModel.DesignerSerializationVisibility.Hidden)>  _
    Public ReadOnly Property Parameter_IJStatusID() As CrystalDecisions.[Shared].IParameterField
        Get
            Return Me.DataDefinition.ParameterFields(12)
        End Get
    End Property
    
    <Browsable(false),  _
     DesignerSerializationVisibilityAttribute(System.ComponentModel.DesignerSerializationVisibility.Hidden)>  _
    Public ReadOnly Property Parameter_PrimaryID() As CrystalDecisions.[Shared].IParameterField
        Get
            Return Me.DataDefinition.ParameterFields(13)
        End Get
    End Property
    
    <Browsable(false),  _
     DesignerSerializationVisibilityAttribute(System.ComponentModel.DesignerSerializationVisibility.Hidden)>  _
    Public ReadOnly Property Parameter_AdjType() As CrystalDecisions.[Shared].IParameterField
        Get
            Return Me.DataDefinition.ParameterFields(14)
        End Get
    End Property
    
    <Browsable(false),  _
     DesignerSerializationVisibilityAttribute(System.ComponentModel.DesignerSerializationVisibility.Hidden)>  _
    Public ReadOnly Property Parameter_AdjDescription() As CrystalDecisions.[Shared].IParameterField
        Get
            Return Me.DataDefinition.ParameterFields(15)
        End Get
    End Property
    
    <Browsable(false),  _
     DesignerSerializationVisibilityAttribute(System.ComponentModel.DesignerSerializationVisibility.Hidden)>  _
    Public ReadOnly Property Parameter_PersonID() As CrystalDecisions.[Shared].IParameterField
        Get
            Return Me.DataDefinition.ParameterFields(16)
        End Get
    End Property
    
    <Browsable(false),  _
     DesignerSerializationVisibilityAttribute(System.ComponentModel.DesignerSerializationVisibility.Hidden)>  _
    Public ReadOnly Property Parameter_FacilityID() As CrystalDecisions.[Shared].IParameterField
        Get
            Return Me.DataDefinition.ParameterFields(17)
        End Get
    End Property
    
    <Browsable(false),  _
     DesignerSerializationVisibilityAttribute(System.ComponentModel.DesignerSerializationVisibility.Hidden)>  _
    Public ReadOnly Property Parameter_FacilityTypeID() As CrystalDecisions.[Shared].IParameterField
        Get
            Return Me.DataDefinition.ParameterFields(18)
        End Get
    End Property
    
    <Browsable(false),  _
     DesignerSerializationVisibilityAttribute(System.ComponentModel.DesignerSerializationVisibility.Hidden)>  _
    Public ReadOnly Property Parameter_SubzoneID() As CrystalDecisions.[Shared].IParameterField
        Get
            Return Me.DataDefinition.ParameterFields(19)
        End Get
    End Property
    
    <Browsable(false),  _
     DesignerSerializationVisibilityAttribute(System.ComponentModel.DesignerSerializationVisibility.Hidden)>  _
    Public ReadOnly Property Parameter_ZoneID() As CrystalDecisions.[Shared].IParameterField
        Get
            Return Me.DataDefinition.ParameterFields(20)
        End Get
    End Property
    
    <Browsable(false),  _
     DesignerSerializationVisibilityAttribute(System.ComponentModel.DesignerSerializationVisibility.Hidden)>  _
    Public ReadOnly Property Parameter_ReportForDepartmentID() As CrystalDecisions.[Shared].IParameterField
        Get
            Return Me.DataDefinition.ParameterFields(21)
        End Get
    End Property
    
    <Browsable(false),  _
     DesignerSerializationVisibilityAttribute(System.ComponentModel.DesignerSerializationVisibility.Hidden)>  _
    Public ReadOnly Property Parameter_SupplierName() As CrystalDecisions.[Shared].IParameterField
        Get
            Return Me.DataDefinition.ParameterFields(22)
        End Get
    End Property
    
    <Browsable(false),  _
     DesignerSerializationVisibilityAttribute(System.ComponentModel.DesignerSerializationVisibility.Hidden)>  _
    Public ReadOnly Property Parameter_DepartmentTypeID() As CrystalDecisions.[Shared].IParameterField
        Get
            Return Me.DataDefinition.ParameterFields(23)
        End Get
    End Property
    
    <Browsable(false),  _
     DesignerSerializationVisibilityAttribute(System.ComponentModel.DesignerSerializationVisibility.Hidden)>  _
    Public ReadOnly Property Parameter_PaymentType() As CrystalDecisions.[Shared].IParameterField
        Get
            Return Me.DataDefinition.ParameterFields(24)
        End Get
    End Property
    
    <Browsable(false),  _
     DesignerSerializationVisibilityAttribute(System.ComponentModel.DesignerSerializationVisibility.Hidden)>  _
    Public ReadOnly Property Parameter_PaymentInstttOrZone() As CrystalDecisions.[Shared].IParameterField
        Get
            Return Me.DataDefinition.ParameterFields(25)
        End Get
    End Property
    
    <Browsable(false),  _
     DesignerSerializationVisibilityAttribute(System.ComponentModel.DesignerSerializationVisibility.Hidden)>  _
    Public ReadOnly Property Parameter_SupplyPeriod() As CrystalDecisions.[Shared].IParameterField
        Get
            Return Me.DataDefinition.ParameterFields(26)
        End Get
    End Property
    
    <Browsable(false),  _
     DesignerSerializationVisibilityAttribute(System.ComponentModel.DesignerSerializationVisibility.Hidden)>  _
    Public ReadOnly Property Parameter_SubTitle() As CrystalDecisions.[Shared].IParameterField
        Get
            Return Me.DataDefinition.ParameterFields(27)
        End Get
    End Property
    
    <Browsable(false),  _
     DesignerSerializationVisibilityAttribute(System.ComponentModel.DesignerSerializationVisibility.Hidden)>  _
    Public ReadOnly Property Parameter_Void() As CrystalDecisions.[Shared].IParameterField
        Get
            Return Me.DataDefinition.ParameterFields(28)
        End Get
    End Property
End Class

<System.Drawing.ToolboxBitmapAttribute(GetType(CrystalDecisions.[Shared].ExportOptions), "report.bmp")>  _
Public Class CachedRPT_IJSMR
    Inherits Component
    Implements ICachedReport
    
    Public Sub New()
        MyBase.New
    End Sub
    
    <Browsable(false),  _
     DesignerSerializationVisibilityAttribute(System.ComponentModel.DesignerSerializationVisibility.Hidden)>  _
    Public Overridable Property IsCacheable() As Boolean Implements CrystalDecisions.ReportSource.ICachedReport.IsCacheable
        Get
            Return true
        End Get
        Set
            '
        End Set
    End Property
    
    <Browsable(false),  _
     DesignerSerializationVisibilityAttribute(System.ComponentModel.DesignerSerializationVisibility.Hidden)>  _
    Public Overridable Property ShareDBLogonInfo() As Boolean Implements CrystalDecisions.ReportSource.ICachedReport.ShareDBLogonInfo
        Get
            Return false
        End Get
        Set
            '
        End Set
    End Property
    
    <Browsable(false),  _
     DesignerSerializationVisibilityAttribute(System.ComponentModel.DesignerSerializationVisibility.Hidden)>  _
    Public Overridable Property CacheTimeOut() As System.TimeSpan Implements CrystalDecisions.ReportSource.ICachedReport.CacheTimeOut
        Get
            Return CachedReportConstants.DEFAULT_TIMEOUT
        End Get
        Set
            '
        End Set
    End Property
    
    Public Overridable Function CreateReport() As CrystalDecisions.CrystalReports.Engine.ReportDocument Implements CrystalDecisions.ReportSource.ICachedReport.CreateReport
        Dim rpt As RPT_IJSMR = New RPT_IJSMR()
        rpt.Site = Me.Site
        Return rpt
    End Function
    
    Public Overridable Function GetCustomizedCacheKey(ByVal request As RequestContext) As String Implements CrystalDecisions.ReportSource.ICachedReport.GetCustomizedCacheKey
        Dim key As [String] = Nothing
        '// The following is the code used to generate the default
        '// cache key for caching report jobs in the ASP.NET Cache.
        '// Feel free to modify this code to suit your needs.
        '// Returning key == null causes the default cache key to
        '// be generated.
        '
        'key = RequestContext.BuildCompleteCacheKey(
        '    request,
        '    null,       // sReportFilename
        '    this.GetType(),
        '    this.ShareDBLogonInfo );
        Return key
    End Function
End Class
