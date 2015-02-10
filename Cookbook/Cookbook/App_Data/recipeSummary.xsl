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
    <!--<xsl:call-template name="super-fact-row">
      <xsl:with-param name="node" select="/recipeSummary/nutritionFacts/nutrition-fact/fats"/>
    </xsl:call-template>-->
  </xsl:template>
  
  <!--<xsl:template match="nutritionFacts">
    <xsl:call-template name="super-fact-row">
      <xsl:with-param name="nodes" select="nutrition-fact/fats" />
    </xsl:call-template>
  </xsl:template>-->

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
   
  <!--<xsl:template name="super-fact-row">
    <xsl:param name="node"/>
    <xsl:param name="category"/>
 --><!--   <xsl:variable name="nutrient-values">
      <values>
      <xsl:for-each select="$node">
        <xsl:variable name="currentId" select="../@id" />
        <xsl:variable name="ingredientQuantity" select="/recipeSummary/ingredients/ingredient[@factId = $currentId]/quantity" />
        <xsl:variable name="childrenSum" select="sum(current()/*)"/>
        <xsl:variable name="factQuantity" select="../@quantity" />
        <value><xsl:value-of select="$childrenSum * $ingredientQuantity div $factQuantity"/></value>     
      </xsl:for-each>
      </values>
    </xsl:variable>
    <xsl:variable name="total" select="sum(msxsl:node-set($nutrient-values)/values/value)"/>--><!--
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
    <xsl:param name="node"/>
    <xsl:param name="category"/>
--><!--    <xsl:variable name="nutrient-values">
      <values>
      <xsl:for-each select="$node">
        <xsl:variable name="currentId" select="../../@id" />
        <xsl:variable name="ingredientQuantity" select="/recipeSummary/ingredients/ingredient[@factId = $currentId]/quantity" />
        <xsl:variable name="value" select="."/>
        <xsl:variable name="factQuantity" select="../../@quantity" />
        <value><xsl:value-of select="$value * $ingredientQuantity div $factQuantity"/></value>     
      </xsl:for-each>
      </values>
    </xsl:variable>
    <xsl:variable name="total" select="sum(msxsl:node-set($nutrient-values)/values/value)"/>--><!--

    <xsl:variable name="total">
      <xsl:call-template name="subFactTotalValueCalculation">
        <xsl:with-param name="node" select="$node"/>
      </xsl:call-template>
    </xsl:variable>
    <xsl:variable name="total-recommended" select="//daily-values/*/*[name(.)=name($node)]" />
    <tr>
      <th colspan="2">
        <b>
          <xsl:value-of select="$category"/>
        </b>
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
  </xsl:template>-->

</xsl:stylesheet>