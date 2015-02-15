<xsl:stylesheet version="1.0"
xmlns:xsl="http://www.w3.org/1999/XSL/Transform">
  <xsl:output method="html" indent="yes"/>
  
  <xsl:template name="nutrition-label">
    <xsl:param name="base"/>
    <div class="performance-facts">
      <header class="performance-facts__header">
        <h1 class="performance-facts__title">
          <xsl:value-of select="food-name"/>
        </h1>
        <p>
          Per serving
        </p>
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
            <xsl:with-param name="node" select="$base/calories" />
          </xsl:call-template>
          <xsl:call-template name="sub-fact-row">
            <xsl:with-param name="category">From carbohydrate</xsl:with-param>
            <xsl:with-param name="node" select="$base/calories/from-carbohydrate" />
          </xsl:call-template>
          <xsl:call-template name="sub-fact-row">
            <xsl:with-param name="category">From fat</xsl:with-param>
            <xsl:with-param name="node" select="$base/calories/from-fat" />
          </xsl:call-template>
          <xsl:call-template name="sub-fact-row">
            <xsl:with-param name="category">From protein</xsl:with-param>
            <xsl:with-param name="node" select="$base/calories/from-protein" />
          </xsl:call-template>
          <!-- FATS -->
          <xsl:call-template name="super-fact-row">
            <xsl:with-param name="category">Total fat</xsl:with-param>
            <xsl:with-param name="node" select="$base/fats" />
          </xsl:call-template>
          <xsl:call-template name="sub-fact-row">
            <xsl:with-param name="category">Saturated fat</xsl:with-param>
            <xsl:with-param name="node" select="$base/fats/saturated-fat" />
          </xsl:call-template>
          <xsl:call-template name="sub-fact-row">
            <xsl:with-param name="category">Monounsaturated fat</xsl:with-param>
            <xsl:with-param name="node" select="$base/fats/monounsaturated-fat" />
          </xsl:call-template>
          <xsl:call-template name="sub-fact-row">
            <xsl:with-param name="category">Polyunsaturated fat</xsl:with-param>
            <xsl:with-param name="node" select="$base/fats/polyunsaturated-fat" />
          </xsl:call-template>

          <!-- CARBOHYDRATES -->
          <xsl:call-template name="super-fact-row">
            <xsl:with-param name="category">Total carbohydrates</xsl:with-param>
            <xsl:with-param name="node" select="$base/carbohydrates" />
          </xsl:call-template>
          <xsl:call-template name="sub-fact-row">
            <xsl:with-param name="category">Dietary fiber</xsl:with-param>
            <xsl:with-param name="node" select="$base/carbohydrates/dietary-fiber" />
          </xsl:call-template>
          <xsl:call-template name="sub-fact-row">
            <xsl:with-param name="category">Sugars</xsl:with-param>
            <xsl:with-param name="node" select="$base/carbohydrates/sugars" />
          </xsl:call-template>

          <!-- MINERALS -->
          <xsl:call-template name="super-fact-row">
            <xsl:with-param name="category">Total minerals</xsl:with-param>
            <xsl:with-param name="node" select="$base/minerals" />
          </xsl:call-template>
          <xsl:call-template name="sub-fact-row">
            <xsl:with-param name="category">Calcium</xsl:with-param>
            <xsl:with-param name="node" select="$base/minerals/Calcium" />
          </xsl:call-template>
          <xsl:call-template name="sub-fact-row">
            <xsl:with-param name="category">Iron</xsl:with-param>
            <xsl:with-param name="node" select="$base/minerals/Iron" />
          </xsl:call-template>
          <xsl:call-template name="sub-fact-row">
            <xsl:with-param name="category">Magnesium</xsl:with-param>
            <xsl:with-param name="node" select="$base/minerals/Magnesium" />
          </xsl:call-template>
          <xsl:call-template name="sub-fact-row">
            <xsl:with-param name="category">Potassium</xsl:with-param>
            <xsl:with-param name="node" select="$base/minerals/Potassium" />
          </xsl:call-template>
          <xsl:call-template name="sub-fact-row">
            <xsl:with-param name="category">Sodium</xsl:with-param>
            <xsl:with-param name="node" select="$base/minerals/Sodium" />
          </xsl:call-template>
        </tbody>
      </table>
      <p class="small-info">* Percent Daily Values are based on a 2,000 calorie diet. Your daily values may be higher or lower depending on your calorie needs:</p>
    </div>
  </xsl:template>

  <xsl:template match="daily-values" />
  
  <xsl:template name="superFactTotalValueCalculation" />
  <xsl:template name="subFactTotalValueCalculation" />

  <xsl:template name="super-fact-row">
    <xsl:param name="category" />
    <xsl:param name="node" />
    <xsl:variable name="total">
      <xsl:call-template name="superFactTotalValueCalculation">
        <xsl:with-param name="node" select="$node"/>
      </xsl:call-template>
    </xsl:variable>
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
        <b>
          <xsl:value-of select="round(100 * $total div $total-recommended)"/>%
        </b>
      </td>
    </tr>
  </xsl:template>

  <xsl:template name="sub-fact-row">
    <xsl:param name="category" />
    <xsl:param name="node" />
    <xsl:variable name="total">
      <xsl:call-template name="subFactTotalValueCalculation">
        <xsl:with-param name="node" select="$node"/>
      </xsl:call-template>
    </xsl:variable>
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
        <b>
          <xsl:value-of select="round(100 * $total div $total-recommended)"/>%
        </b>
      </td>
    </tr>
  </xsl:template>
</xsl:stylesheet>