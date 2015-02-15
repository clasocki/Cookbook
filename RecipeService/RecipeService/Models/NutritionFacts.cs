﻿//------------------------------------------------------------------------------
// <auto-generated>
//     Ten kod został wygenerowany przez narzędzie.
//     Wersja wykonawcza:4.0.30319.34014
//
//     Zmiany w tym pliku mogą spowodować nieprawidłowe zachowanie i zostaną utracone, jeśli
//     kod zostanie ponownie wygenerowany.
// </auto-generated>
//------------------------------------------------------------------------------

using System.Xml.Serialization;

// 
// This source code was auto-generated by xsd, Version=4.0.30319.18020.
// 


/// <uwagi/>
[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.18020")]
[System.SerializableAttribute()]
[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://students.mimuw.edu.pl/~cl320813/nutritionFacts")]
[System.Xml.Serialization.XmlRootAttribute("nutritionData", Namespace = "http://students.mimuw.edu.pl/~cl320813/nutritionFacts", IsNullable = false)]
public partial class NutritionData
{

    private NutritionFact[] nutritionfactsField;

    private DailyValues dailyvaluesField;

    /// <uwagi/>
    [System.Xml.Serialization.XmlArrayAttribute("nutrition-facts", Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
    [System.Xml.Serialization.XmlArrayItemAttribute("nutrition-fact", Form = System.Xml.Schema.XmlSchemaForm.Unqualified, IsNullable = false)]
    public NutritionFact[] nutritionfacts
    {
        get
        {
            return this.nutritionfactsField;
        }
        set
        {
            this.nutritionfactsField = value;
        }
    }

    /// <uwagi/>
    [System.Xml.Serialization.XmlElementAttribute("daily-values", Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
    public DailyValues dailyvalues
    {
        get
        {
            return this.dailyvaluesField;
        }
        set
        {
            this.dailyvaluesField = value;
        }
    }
}

/// <uwagi/>
[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.18020")]
[System.SerializableAttribute()]
[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://students.mimuw.edu.pl/~cl320813/nutritionFacts")]
public partial class NutritionFact
{

    private string foodnameField;

    private Fats fatsField;

    private Calories caloriesField;

    private Carbohydrates carbohydratesField;

    private Minerals mineralsField;

    private int idField;

    private decimal quantityField;

    private MeasurementUnit unitsField;

    /// <uwagi/>
    [System.Xml.Serialization.XmlElementAttribute("food-name", Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
    public string foodname
    {
        get
        {
            return this.foodnameField;
        }
        set
        {
            this.foodnameField = value;
        }
    }

    /// <uwagi/>
    [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
    public Fats fats
    {
        get
        {
            return this.fatsField;
        }
        set
        {
            this.fatsField = value;
        }
    }

    /// <uwagi/>
    [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
    public Calories calories
    {
        get
        {
            return this.caloriesField;
        }
        set
        {
            this.caloriesField = value;
        }
    }

    /// <uwagi/>
    [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
    public Carbohydrates carbohydrates
    {
        get
        {
            return this.carbohydratesField;
        }
        set
        {
            this.carbohydratesField = value;
        }
    }

    /// <uwagi/>
    [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
    public Minerals minerals
    {
        get
        {
            return this.mineralsField;
        }
        set
        {
            this.mineralsField = value;
        }
    }

    /// <uwagi/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public int id
    {
        get
        {
            return this.idField;
        }
        set
        {
            this.idField = value;
        }
    }

    /// <uwagi/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public decimal quantity
    {
        get
        {
            return this.quantityField;
        }
        set
        {
            this.quantityField = value;
        }
    }

    /// <uwagi/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public MeasurementUnit units
    {
        get
        {
            return this.unitsField;
        }
        set
        {
            this.unitsField = value;
        }
    }

    [XmlIgnore]
    public double Density { get; set; }
}

/// <uwagi/>
[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.18020")]
[System.SerializableAttribute()]
[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://students.mimuw.edu.pl/~cl320813/nutritionFacts")]
public partial class Fats
{

    private decimal saturatedfatField;

    private decimal monounsaturatedfatField;

    private decimal polyunsaturatedfatField;

    private WeightUnit unitsField;

    /// <uwagi/>
    [System.Xml.Serialization.XmlElementAttribute("saturated-fat", Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
    public decimal saturatedfat
    {
        get
        {
            return this.saturatedfatField;
        }
        set
        {
            this.saturatedfatField = value;
        }
    }

    /// <uwagi/>
    [System.Xml.Serialization.XmlElementAttribute("monounsaturated-fat", Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
    public decimal monounsaturatedfat
    {
        get
        {
            return this.monounsaturatedfatField;
        }
        set
        {
            this.monounsaturatedfatField = value;
        }
    }

    /// <uwagi/>
    [System.Xml.Serialization.XmlElementAttribute("polyunsaturated-fat", Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
    public decimal polyunsaturatedfat
    {
        get
        {
            return this.polyunsaturatedfatField;
        }
        set
        {
            this.polyunsaturatedfatField = value;
        }
    }

    /// <uwagi/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public WeightUnit units
    {
        get
        {
            return this.unitsField;
        }
        set
        {
            this.unitsField = value;
        }
    }
}

/// <uwagi/>
[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.18020")]
[System.SerializableAttribute()]
[System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://students.mimuw.edu.pl/~cl320813/nutritionFacts")]
public enum WeightUnit
{

    /// <uwagi/>
    kg,

    /// <uwagi/>
    dag,

    /// <uwagi/>
    g,

    /// <uwagi/>
    mg,

    /// <uwagi/>
    oz,

    /// <uwagi/>
    lb,
}

/// <uwagi/>
[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.18020")]
[System.SerializableAttribute()]
[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://students.mimuw.edu.pl/~cl320813/nutritionFacts")]
public partial class DailyValues
{
    [XmlIgnore]
    public int id { get; set; }

    private Fats fatsField;

    private Calories caloriesField;

    private Carbohydrates carbohydratesField;

    private Minerals mineralsField;

    /// <uwagi/>
    [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
    public Fats fats
    {
        get
        {
            return this.fatsField;
        }
        set
        {
            this.fatsField = value;
        }
    }

    /// <uwagi/>
    [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
    public Calories calories
    {
        get
        {
            return this.caloriesField;
        }
        set
        {
            this.caloriesField = value;
        }
    }

    /// <uwagi/>
    [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
    public Carbohydrates carbohydrates
    {
        get
        {
            return this.carbohydratesField;
        }
        set
        {
            this.carbohydratesField = value;
        }
    }

    /// <uwagi/>
    [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
    public Minerals minerals
    {
        get
        {
            return this.mineralsField;
        }
        set
        {
            this.mineralsField = value;
        }
    }
}

/// <uwagi/>
[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.18020")]
[System.SerializableAttribute()]
[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://students.mimuw.edu.pl/~cl320813/nutritionFacts")]
public partial class Calories
{

    private decimal fromcarbohydrateField;

    private decimal fromfatField;

    private decimal fromproteinField;

    private EnergyUnit unitsField;

    /// <uwagi/>
    [System.Xml.Serialization.XmlElementAttribute("from-carbohydrate", Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
    public decimal fromcarbohydrate
    {
        get
        {
            return this.fromcarbohydrateField;
        }
        set
        {
            this.fromcarbohydrateField = value;
        }
    }

    /// <uwagi/>
    [System.Xml.Serialization.XmlElementAttribute("from-fat", Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
    public decimal fromfat
    {
        get
        {
            return this.fromfatField;
        }
        set
        {
            this.fromfatField = value;
        }
    }

    /// <uwagi/>
    [System.Xml.Serialization.XmlElementAttribute("from-protein", Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
    public decimal fromprotein
    {
        get
        {
            return this.fromproteinField;
        }
        set
        {
            this.fromproteinField = value;
        }
    }

    /// <uwagi/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public EnergyUnit units
    {
        get
        {
            return this.unitsField;
        }
        set
        {
            this.unitsField = value;
        }
    }
}

/// <uwagi/>
[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.18020")]
[System.SerializableAttribute()]
[System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://students.mimuw.edu.pl/~cl320813/nutritionFacts")]
public enum EnergyUnit
{
    /// <uwagi/>
    kcal
}

/// <uwagi/>
[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.18020")]
[System.SerializableAttribute()]
[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://students.mimuw.edu.pl/~cl320813/nutritionFacts")]
public partial class Carbohydrates
{

    private decimal dietaryfiberField;

    private decimal sugarsField;

    private WeightUnit unitsField;

    /// <uwagi/>
    [System.Xml.Serialization.XmlElementAttribute("dietary-fiber", Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
    public decimal dietaryfiber
    {
        get
        {
            return this.dietaryfiberField;
        }
        set
        {
            this.dietaryfiberField = value;
        }
    }

    /// <uwagi/>
    [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
    public decimal sugars
    {
        get
        {
            return this.sugarsField;
        }
        set
        {
            this.sugarsField = value;
        }
    }

    /// <uwagi/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public WeightUnit units
    {
        get
        {
            return this.unitsField;
        }
        set
        {
            this.unitsField = value;
        }
    }
}

/// <uwagi/>
[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.18020")]
[System.SerializableAttribute()]
[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://students.mimuw.edu.pl/~cl320813/nutritionFacts")]
public partial class Minerals
{

    private decimal calciumField;

    private decimal ironField;

    private decimal magnesiumField;

    private decimal potassiumField;

    private decimal sodiumField;

    private WeightUnit unitsField;

    /// <uwagi/>
    [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
    public decimal Calcium
    {
        get
        {
            return this.calciumField;
        }
        set
        {
            this.calciumField = value;
        }
    }

    /// <uwagi/>
    [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
    public decimal Iron
    {
        get
        {
            return this.ironField;
        }
        set
        {
            this.ironField = value;
        }
    }

    /// <uwagi/>
    [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
    public decimal Magnesium
    {
        get
        {
            return this.magnesiumField;
        }
        set
        {
            this.magnesiumField = value;
        }
    }

    /// <uwagi/>
    [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
    public decimal Potassium
    {
        get
        {
            return this.potassiumField;
        }
        set
        {
            this.potassiumField = value;
        }
    }

    /// <uwagi/>
    [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
    public decimal Sodium
    {
        get
        {
            return this.sodiumField;
        }
        set
        {
            this.sodiumField = value;
        }
    }

    /// <uwagi/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public WeightUnit units
    {
        get
        {
            return this.unitsField;
        }
        set
        {
            this.unitsField = value;
        }
    }
}
