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
[System.Xml.Serialization.XmlTypeAttribute(Namespace="http://students.mimuw.edu.pl/~cl320813/recipes")]
[System.Xml.Serialization.XmlRootAttribute("recipes", Namespace="http://students.mimuw.edu.pl/~cl320813/recipes", IsNullable=false)]
public partial class Recipes {
    
    private Recipe[] recipeField;
    
    /// <uwagi/>
    [System.Xml.Serialization.XmlElementAttribute("recipe", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
    public Recipe[] recipe {
        get {
            return this.recipeField;
        }
        set {
            this.recipeField = value;
        }
    }
}

/// <uwagi/>
[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.18020")]
[System.SerializableAttribute()]
[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(Namespace="http://students.mimuw.edu.pl/~cl320813/recipes")]
public partial class Recipe {
    
    private string titleField;
    
    private PreparationTime preparationTimeField;
    
    private int portionsField;
    
    private Ingredient[] ingredientsField;
    
    private RecipeSection[] contentField;
    
    private int idField;
    
    /// <uwagi/>
    [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
    public string title {
        get {
            return this.titleField;
        }
        set {
            this.titleField = value;
        }
    }
    
    /// <uwagi/>
    [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
    public PreparationTime preparationTime {
        get {
            return this.preparationTimeField;
        }
        set {
            this.preparationTimeField = value;
        }
    }
    
    /// <uwagi/>
    [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
    public int portions {
        get {
            return this.portionsField;
        }
        set {
            this.portionsField = value;
        }
    }
    
    /// <uwagi/>
    [System.Xml.Serialization.XmlArrayAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
    [System.Xml.Serialization.XmlArrayItemAttribute("ingredient", Form=System.Xml.Schema.XmlSchemaForm.Unqualified, IsNullable=false)]
    public Ingredient[] ingredients {
        get {
            return this.ingredientsField;
        }
        set {
            this.ingredientsField = value;
        }
    }
    
    /// <uwagi/>
    [System.Xml.Serialization.XmlArrayAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
    [System.Xml.Serialization.XmlArrayItemAttribute("section", Form=System.Xml.Schema.XmlSchemaForm.Unqualified, IsNullable=false)]
    public RecipeSection[] content {
        get {
            return this.contentField;
        }
        set {
            this.contentField = value;
        }
    }
    
    /// <uwagi/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public int id {
        get {
            return this.idField;
        }
        set {
            this.idField = value;
        }
    }
}

/// <uwagi/>
[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.18020")]
[System.SerializableAttribute()]
[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(Namespace="http://students.mimuw.edu.pl/~cl320813/recipes")]
public partial class PreparationTime {
    
    private TimeUnit unitsField;
    
    private bool unitsFieldSpecified;
    
    private decimal valueField;
    
    /// <uwagi/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public TimeUnit units {
        get {
            return this.unitsField;
        }
        set {
            this.unitsField = value;
        }
    }
    
    /// <uwagi/>
    [System.Xml.Serialization.XmlIgnoreAttribute()]
    public bool unitsSpecified {
        get {
            return this.unitsFieldSpecified;
        }
        set {
            this.unitsFieldSpecified = value;
        }
    }
    
    /// <uwagi/>
    [System.Xml.Serialization.XmlTextAttribute()]
    public decimal Value {
        get {
            return this.valueField;
        }
        set {
            this.valueField = value;
        }
    }
}

/// <uwagi/>
[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.18020")]
[System.SerializableAttribute()]
[System.Xml.Serialization.XmlTypeAttribute(Namespace="http://students.mimuw.edu.pl/~cl320813/recipes")]
public enum TimeUnit {
    
    /// <uwagi/>
    h,
    
    /// <uwagi/>
    min,
    
    /// <uwagi/>
    s,
}

/// <uwagi/>
[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.18020")]
[System.SerializableAttribute()]
[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(Namespace="http://students.mimuw.edu.pl/~cl320813/recipes")]
public partial class RecipeSection {
    
    private string nameField;
    
    private string[] textField;
    
    /// <uwagi/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public string name {
        get {
            return this.nameField;
        }
        set {
            this.nameField = value;
        }
    }
    
    /// <uwagi/>
    [System.Xml.Serialization.XmlTextAttribute()]
    public string[] Text {
        get {
            return this.textField;
        }
        set {
            this.textField = value;
        }
    }
}

/// <uwagi/>
[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.18020")]
[System.SerializableAttribute()]
[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(Namespace="http://students.mimuw.edu.pl/~cl320813/recipes")]
public partial class Ingredient {
    
    private string nameField;
    
    private decimal quantityField;
    
    private MeasurementUnit unitsField;
    
    private int factIdField;
    
    /// <uwagi/>
    [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
    public string name {
        get {
            return this.nameField;
        }
        set {
            this.nameField = value;
        }
    }
    
    /// <uwagi/>
    [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
    public decimal quantity {
        get {
            return this.quantityField;
        }
        set {
            this.quantityField = value;
        }
    }
    
    /// <uwagi/>
    [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
    public MeasurementUnit units {
        get {
            return this.unitsField;
        }
        set {
            this.unitsField = value;
        }
    }
    
    /// <uwagi/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public int factId {
        get {
            return this.factIdField;
        }
        set {
            this.factIdField = value;
        }
    }
}

/// <uwagi/>
[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.18020")]
[System.SerializableAttribute()]
[System.Xml.Serialization.XmlTypeAttribute(Namespace="http://students.mimuw.edu.pl/~cl320813/recipes")]
public enum MeasurementUnit {
    
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
    
    /// <uwagi/>
    l,
    
    /// <uwagi/>
    ml,
    
    /// <uwagi/>
    tsp,
    
    /// <uwagi/>
    tbsp,
    
    /// <uwagi/>
    cup,
}
