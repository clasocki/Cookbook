<?xml version="1.0" encoding="UTF-8"?>

<xsl:stylesheet version="1.0"
xmlns:xsl="http://www.w3.org/1999/XSL/Transform">
  <xsl:output method="html" indent="yes"/> 
  <xsl:param name="quantity" />
  
  <xsl:template match="nutrition-fact">
    <div class="performance-facts">
      <header class="performance-facts__header">
        <h1 class="performance-facts__title"><xsl:value-of select="food-name"/></h1>
        <p>Serving Size <xsl:value-of select="$quantity"/> <xsl:value-of select="@units"/> </p>
      </header>
      <table class="performance-facts__table">
        <thead>
          <tr>
            <th colspan="3" class="small-info">
              Amount Per Serving
            </th>
          </tr>
        </thead>
        <tbody>
        <tr class="thick-row">
            <td colspan="3" class="small-info">
              <b>% Daily Value*</b>
            </td>
        </tr>
        <!-- CALORIES -->
        <xsl:call-template name="super-fact-row">
          <xsl:with-param name="category">Calories</xsl:with-param>
          <xsl:with-param name="node" select="calories" />
        </xsl:call-template>
        <xsl:call-template name="sub-fact-row">
          <xsl:with-param name="category">From carbohydrate</xsl:with-param>
          <xsl:with-param name="node" select="calories/from-carbohydrate" />
        </xsl:call-template>
        <xsl:call-template name="sub-fact-row">
          <xsl:with-param name="category">From fat</xsl:with-param>
          <xsl:with-param name="node" select="calories/from-fat" />
        </xsl:call-template>
        <xsl:call-template name="sub-fact-row">
          <xsl:with-param name="category">From protein</xsl:with-param>
          <xsl:with-param name="node" select="calories/from-protein" />
        </xsl:call-template>
        <!-- FATS -->
        <xsl:call-template name="super-fact-row">
          <xsl:with-param name="category">Total fat</xsl:with-param>
          <xsl:with-param name="node" select="fats" />
        </xsl:call-template>
        <xsl:call-template name="sub-fact-row">
          <xsl:with-param name="category">Saturated fat</xsl:with-param>
          <xsl:with-param name="node" select="fats/saturated-fat" />
        </xsl:call-template>
        <xsl:call-template name="sub-fact-row">
          <xsl:with-param name="category">Monounsaturated fat</xsl:with-param>
          <xsl:with-param name="node" select="fats/monounsaturated-fat" />
        </xsl:call-template>
        <xsl:call-template name="sub-fact-row">
          <xsl:with-param name="category">Polyunsaturated fat</xsl:with-param>
          <xsl:with-param name="node" select="fats/polyunsaturated-fat" />
        </xsl:call-template>
  
        <!-- CARBOHYDRATES -->
        <xsl:call-template name="super-fact-row">
          <xsl:with-param name="category">Total carbohydrates</xsl:with-param>
          <xsl:with-param name="node" select="carbohydrates" />
        </xsl:call-template>
        <xsl:call-template name="sub-fact-row">
          <xsl:with-param name="category">Dietary fiber</xsl:with-param>
          <xsl:with-param name="node" select="carbohydrates/dietary-fiber" />
        </xsl:call-template>
        <xsl:call-template name="sub-fact-row">
          <xsl:with-param name="category">Sugars</xsl:with-param>
          <xsl:with-param name="node" select="carbohydrates/sugars" />
        </xsl:call-template>
        
        <!-- MINERALS -->
        <xsl:call-template name="super-fact-row">
          <xsl:with-param name="category">Total minerals</xsl:with-param>
          <xsl:with-param name="node" select="minerals" />
        </xsl:call-template>
        <xsl:call-template name="sub-fact-row">
          <xsl:with-param name="category">Calcium</xsl:with-param>
          <xsl:with-param name="node" select="minerals/Calcium" />
        </xsl:call-template>
        <xsl:call-template name="sub-fact-row">
          <xsl:with-param name="category">Iron</xsl:with-param>
          <xsl:with-param name="node" select="minerals/Iron" />
        </xsl:call-template>
        <xsl:call-template name="sub-fact-row">
          <xsl:with-param name="category">Magnesium</xsl:with-param>
          <xsl:with-param name="node" select="minerals/Magnesium" />
        </xsl:call-template>
        <xsl:call-template name="sub-fact-row">
          <xsl:with-param name="category">Potassium</xsl:with-param>
          <xsl:with-param name="node" select="minerals/Potassium" />
        </xsl:call-template>
        <xsl:call-template name="sub-fact-row">
          <xsl:with-param name="category">Sodium</xsl:with-param>
          <xsl:with-param name="node" select="minerals/Sodium" />
        </xsl:call-template>
        
        <!-- PROTEINS -->
        <xsl:call-template name="single-super-fact-row">
          <xsl:with-param name="category">Proteins</xsl:with-param>
          <xsl:with-param name="node" select="proteins" />
        </xsl:call-template>
        
        <!-- VITAMINS -->
        <xsl:call-template name="super-fact-row">
          <xsl:with-param name="category">Total vitamins</xsl:with-param>
          <xsl:with-param name="node" select="vitamins" />
        </xsl:call-template>
        <xsl:call-template name="sub-fact-row">
          <xsl:with-param name="category">A</xsl:with-param>
          <xsl:with-param name="node" select="vitamins/A" />
        </xsl:call-template>
        <xsl:call-template name="sub-fact-row">
          <xsl:with-param name="category">C</xsl:with-param>
          <xsl:with-param name="node" select="vitamins/C" />
        </xsl:call-template>
        <xsl:call-template name="sub-fact-row">
          <xsl:with-param name="category">D</xsl:with-param>
          <xsl:with-param name="node" select="vitamins/D" />
        </xsl:call-template>
        <xsl:call-template name="sub-fact-row">
          <xsl:with-param name="category">E</xsl:with-param>
          <xsl:with-param name="node" select="vitamins/E" />
        </xsl:call-template>
        </tbody>
      </table>
      <p class="small-info">* Percent Daily Values are based on a 2,000 calorie diet. Your daily values may be higher or lower depending on your calorie needs:</p>
    </div>
  </xsl:template>
  
  <xsl:template match="daily-values" />

  <xsl:template name="super-fact-row">
    <xsl:param name="category" />
    <xsl:param name="node" />
    <xsl:variable name="total" select="sum($node/*) * $quantity" />
    <xsl:variable name="total-recommended" select="sum(//daily-values/*[name(.)=name($node)]/*)" />
    <tr>
      <th colspan="2">
        <b>
          <xsl:value-of select="$category"/>
        </b>
        <xsl:text> </xsl:text>
        <xsl:value-of select="$total"/>
        <xsl:value-of select="$node/@units"/>
      </th>
      <td>
        <b><xsl:value-of select="round(100 * $total div $total-recommended)"/>%</b>
      </td>
    </tr>
  </xsl:template>
  
  <xsl:template name="sub-fact-row">
    <xsl:param name="category" />
    <xsl:param name="node" />
    <xsl:variable name="total" select="$node * $quantity"/>
    <xsl:variable name="total-recommended" select="//daily-values/*/*[name(.)=name($node)]" />
    <tr>
      <td class="blank-cell">
      </td>
      <th>
        <xsl:value-of select="$category" />
        <xsl:text> </xsl:text>
        <xsl:value-of select="$total"/>
        <xsl:value-of select="$node/../@units"/>
      </th>
      <td>
        <b><xsl:value-of select="round(100 * $total div $total-recommended)"/>%</b>
      </td>
    </tr>
  </xsl:template>

  <xsl:template name="single-super-fact-row">
    <xsl:param name="category" />
    <xsl:param name="node" />
    <xsl:variable name="total" select="$node * $quantity" />
    <tr>
      <th colspan="2">
        <b>
          <xsl:value-of select="$category"/>
        </b>
        <xsl:text> </xsl:text>
        <xsl:value-of select="$total"/>
        <xsl:value-of select="$node/@units"/>
      </th>
      <td>
        <b>
          <xsl:value-of select="round(100 * $total div //daily-values/*[name(.)=name($node)])"/>%
        </b>
      </td>
    </tr>
  </xsl:template>

</xsl:stylesheet>