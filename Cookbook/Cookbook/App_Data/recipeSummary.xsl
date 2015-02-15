<?xml version="1.0" encoding="UTF-8"?>

<xsl:stylesheet version="1.0"
  xmlns:xsl="http://www.w3.org/1999/XSL/Transform"
  xmlns:msxsl="urn:schemas-microsoft-com:xslt" xmlns:rs="http://tempuri.org/recipeSummary.xsd">
  <xsl:import href="nutritionLabel.xsl"/>
  <xsl:output method="html" indent="yes"/>

  <xsl:template match="/">
    <xsl:call-template name="nutrition-label">
      <xsl:with-param name="base" select="/rs:recipe-summary/nutrition-facts/nutrition-fact"/>
    </xsl:call-template>
  </xsl:template>

  <xsl:template name="superFactTotalValueCalculation">
    <xsl:param name="node"/>
    <xsl:variable name="nutrient-values">
      <values>
        <xsl:for-each select="$node">
          <xsl:variable name="currentId" select="../@id" />
          <xsl:variable name="ingredientQuantity" select="/rs:recipe-summary/ingredients/ingredient[@factId = $currentId]/quantity" />
          <xsl:variable name="childrenSum" select="sum(current()/*)"/>
          <xsl:variable name="factQuantity" select="../@quantity" />
          <value>
            <xsl:value-of select="$childrenSum * $ingredientQuantity div $factQuantity"/>
          </value>
        </xsl:for-each>
      </values>
    </xsl:variable>
    <xsl:value-of select="sum(msxsl:node-set($nutrient-values)/values/value)"/>
  </xsl:template>

  <xsl:template name="subFactTotalValueCalculation">
    <xsl:param name="node"/>
    <xsl:variable name="nutrient-values">
      <values>
        <xsl:for-each select="$node">
          <xsl:variable name="currentId" select="../../@id" />
          <xsl:variable name="ingredientQuantity" select="/rs:recipe-summary/ingredients/ingredient[@factId = $currentId]/quantity" />
          <xsl:variable name="value" select="."/>
          <xsl:variable name="factQuantity" select="../../@quantity" />
          <value>
            <xsl:value-of select="$value * $ingredientQuantity div $factQuantity"/>
          </value>
        </xsl:for-each>
      </values>
    </xsl:variable>
    <xsl:value-of select="sum(msxsl:node-set($nutrient-values)/values/value)"/>
  </xsl:template>

</xsl:stylesheet>