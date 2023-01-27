<?php

use Twig\Environment;
use Twig\Error\LoaderError;
use Twig\Error\RuntimeError;
use Twig\Extension\SandboxExtension;
use Twig\Markup;
use Twig\Sandbox\SecurityError;
use Twig\Sandbox\SecurityNotAllowedTagError;
use Twig\Sandbox\SecurityNotAllowedFilterError;
use Twig\Sandbox\SecurityNotAllowedFunctionError;
use Twig\Source;
use Twig\Template;

/* table/search/index.twig */
class __TwigTemplate_ea418230843c24587d2ead0c065a0bc884cba9635613140baa53ff92e2ce69d7 extends \Twig\Template
{
    private $source;
    private $macros = [];

    public function __construct(Environment $env)
    {
        parent::__construct($env);

        $this->source = $this->getSourceContext();

        $this->parent = false;

        $this->blocks = [
        ];
    }

    protected function doDisplay(array $context, array $blocks = [])
    {
        $macros = $this->macros;
        // line 1
        echo "<ul class=\"nav nav-pills m-2\">
  <li class=\"nav-item\">
    <a class=\"nav-link active\" href=\"";
        // line 3
        echo PhpMyAdmin\Url::getFromRoute("/table/search", ["db" => ($context["db"] ?? null), "table" => ($context["table"] ?? null), "pos" => 0]);
        echo "\">
      ";
        // line 4
        echo \PhpMyAdmin\Html\Generator::getIcon("b_search", _gettext("Table search"), false, false, "TabsMode");
        echo "
    </a>
  </li>

  <li class=\"nav-item\">
    <a class=\"nav-link\" href=\"";
        // line 9
        echo PhpMyAdmin\Url::getFromRoute("/table/zoom-search", ["db" => ($context["db"] ?? null), "table" => ($context["table"] ?? null)]);
        echo "\">
      ";
        // line 10
        echo \PhpMyAdmin\Html\Generator::getIcon("b_select", _gettext("Zoom search"), false, false, "TabsMode");
        echo "
    </a>
  </li>

  <li class=\"nav-item\">
    <a class=\"nav-link\" href=\"";
        // line 15
        echo PhpMyAdmin\Url::getFromRoute("/table/find-replace", ["db" => ($context["db"] ?? null), "table" => ($context["table"] ?? null)]);
        echo "\">
      ";
        // line 16
        echo \PhpMyAdmin\Html\Generator::getIcon("b_find_replace", _gettext("Find and replace"), false, false, "TabsMode");
        echo "
    </a>
  </li>
</ul>

<form method=\"post\" action=\"";
        // line 21
        echo PhpMyAdmin\Url::getFromRoute("/table/search");
        echo "\" name=\"insertForm\" id=\"tbl_search_form\" class=\"ajax lock-page\">
  ";
        // line 22
        echo PhpMyAdmin\Url::getHiddenInputs(($context["db"] ?? null), ($context["table"] ?? null));
        echo "
  <input type=\"hidden\" name=\"goto\" value=\"";
        // line 23
        echo twig_escape_filter($this->env, ($context["goto"] ?? null), "html", null, true);
        echo "\">
  <input type=\"hidden\" name=\"back\" value=\"";
        // line 24
        echo PhpMyAdmin\Url::getFromRoute("/table/search");
        echo "\">

  <fieldset id=\"fieldset_table_search\">
    <fieldset id=\"fieldset_table_qbe\">
      <legend>
        ";
        // line 29
        echo _gettext("Do a \"query by example\" (wildcard: \"%\")");
        // line 30
        echo "      </legend>
      <div class=\"table-responsive-md jsresponsive\">
        <table class=\"table table-light table-striped table-hover table-sm w-auto\">
          <thead class=\"thead-light\">
            <tr>
              ";
        // line 35
        if (($context["geom_column_flag"] ?? null)) {
            // line 36
            echo "                <th>";
            echo _gettext("Function");
            echo "</th>
              ";
        }
        // line 38
        echo "              <th>";
        echo _gettext("Column");
        echo "</th>
              <th>";
        // line 39
        echo _gettext("Type");
        echo "</th>
              <th>";
        // line 40
        echo _gettext("Collation");
        echo "</th>
              <th>";
        // line 41
        echo _gettext("Operator");
        echo "</th>
              <th>";
        // line 42
        echo _gettext("Value");
        echo "</th>
            </tr>
          </thead>
          <tbody>
            ";
        // line 46
        $context['_parent'] = $context;
        $context['_seq'] = twig_ensure_traversable(range(0, (twig_length_filter($this->env, ($context["column_names"] ?? null)) - 1)));
        foreach ($context['_seq'] as $context["_key"] => $context["column_index"]) {
            // line 47
            echo "              <tr class=\"noclick\">
                ";
            // line 49
            echo "                ";
            if (($context["geom_column_flag"] ?? null)) {
                // line 50
                echo "                  ";
                // line 51
                echo "                  <td>
                    ";
                // line 52
                $context["geom_types"] = PhpMyAdmin\Util::getGISDatatypes();
                // line 53
                echo "                    ";
                if (twig_in_filter((($__internal_compile_0 = ($context["column_types"] ?? null)) && is_array($__internal_compile_0) || $__internal_compile_0 instanceof ArrayAccess ? ($__internal_compile_0[$context["column_index"]] ?? null) : null), ($context["geom_types"] ?? null))) {
                    // line 54
                    echo "                      <select class=\"geom_func\" name=\"geom_func[";
                    echo twig_escape_filter($this->env, $context["column_index"], "html", null, true);
                    echo "]\">
                        ";
                    // line 56
                    echo "                        ";
                    $context["funcs"] = PhpMyAdmin\Util::getGISFunctions((($__internal_compile_1 = ($context["column_types"] ?? null)) && is_array($__internal_compile_1) || $__internal_compile_1 instanceof ArrayAccess ? ($__internal_compile_1[$context["column_index"]] ?? null) : null), true, true);
                    // line 57
                    echo "                        ";
                    $context['_parent'] = $context;
                    $context['_seq'] = twig_ensure_traversable(($context["funcs"] ?? null));
                    foreach ($context['_seq'] as $context["func_name"] => $context["func"]) {
                        // line 58
                        echo "                          ";
                        $context["name"] = ((twig_get_attribute($this->env, $this->source, $context["func"], "display", [], "array", true, true, false, 58)) ? ((($__internal_compile_2 = $context["func"]) && is_array($__internal_compile_2) || $__internal_compile_2 instanceof ArrayAccess ? ($__internal_compile_2["display"] ?? null) : null)) : ($context["func_name"]));
                        // line 59
                        echo "                          <option value=\"";
                        echo twig_escape_filter($this->env, ($context["name"] ?? null), "html", null, true);
                        echo "\">
                            ";
                        // line 60
                        echo twig_escape_filter($this->env, ($context["name"] ?? null), "html", null, true);
                        echo "
                          </option>
                        ";
                    }
                    $_parent = $context['_parent'];
                    unset($context['_seq'], $context['_iterated'], $context['func_name'], $context['func'], $context['_parent'], $context['loop']);
                    $context = array_intersect_key($context, $_parent) + $_parent;
                    // line 63
                    echo "                      </select>
                    ";
                }
                // line 65
                echo "                  </td>
                ";
            }
            // line 67
            echo "                ";
            // line 68
            echo "                <th>";
            // line 70
            echo twig_escape_filter($this->env, (($__internal_compile_3 = ($context["column_names"] ?? null)) && is_array($__internal_compile_3) || $__internal_compile_3 instanceof ArrayAccess ? ($__internal_compile_3[$context["column_index"]] ?? null) : null), "html", null, true);
            // line 71
            echo "</th>
                ";
            // line 72
            $context["properties"] = twig_get_attribute($this->env, $this->source, ($context["self"] ?? null), "getColumnProperties", [0 => $context["column_index"], 1 => $context["column_index"]], "method", false, false, false, 72);
            // line 73
            echo "                <td dir=\"ltr\">
                  ";
            // line 74
            echo twig_escape_filter($this->env, (($__internal_compile_4 = ($context["properties"] ?? null)) && is_array($__internal_compile_4) || $__internal_compile_4 instanceof ArrayAccess ? ($__internal_compile_4["type"] ?? null) : null), "html", null, true);
            echo "
                </td>
                <td>
                  ";
            // line 77
            echo twig_escape_filter($this->env, (($__internal_compile_5 = ($context["properties"] ?? null)) && is_array($__internal_compile_5) || $__internal_compile_5 instanceof ArrayAccess ? ($__internal_compile_5["collation"] ?? null) : null), "html", null, true);
            echo "
                </td>
                <td>
                  ";
            // line 80
            echo (($__internal_compile_6 = ($context["properties"] ?? null)) && is_array($__internal_compile_6) || $__internal_compile_6 instanceof ArrayAccess ? ($__internal_compile_6["func"] ?? null) : null);
            echo "
                </td>
                ";
            // line 83
            echo "                <td data-type=\"";
            echo twig_escape_filter($this->env, (($__internal_compile_7 = ($context["properties"] ?? null)) && is_array($__internal_compile_7) || $__internal_compile_7 instanceof ArrayAccess ? ($__internal_compile_7["type"] ?? null) : null), "html", null, true);
            echo "\">
                  ";
            // line 84
            echo (($__internal_compile_8 = ($context["properties"] ?? null)) && is_array($__internal_compile_8) || $__internal_compile_8 instanceof ArrayAccess ? ($__internal_compile_8["value"] ?? null) : null);
            echo "
                  ";
            // line 86
            echo "                  <input type=\"hidden\" name=\"criteriaColumnNames[";
            echo twig_escape_filter($this->env, $context["column_index"], "html", null, true);
            echo "]\" value=\"";
            echo twig_escape_filter($this->env, (($__internal_compile_9 = ($context["column_names"] ?? null)) && is_array($__internal_compile_9) || $__internal_compile_9 instanceof ArrayAccess ? ($__internal_compile_9[$context["column_index"]] ?? null) : null), "html", null, true);
            echo "\">
                  <input type=\"hidden\" name=\"criteriaColumnTypes[";
            // line 87
            echo twig_escape_filter($this->env, $context["column_index"], "html", null, true);
            echo "]\" value=\"";
            echo twig_escape_filter($this->env, (($__internal_compile_10 = ($context["column_types"] ?? null)) && is_array($__internal_compile_10) || $__internal_compile_10 instanceof ArrayAccess ? ($__internal_compile_10[$context["column_index"]] ?? null) : null), "html", null, true);
            echo "\">
                  <input type=\"hidden\" name=\"criteriaColumnCollations[";
            // line 88
            echo twig_escape_filter($this->env, $context["column_index"], "html", null, true);
            echo "]\" value=\"";
            echo twig_escape_filter($this->env, (($__internal_compile_11 = ($context["column_collations"] ?? null)) && is_array($__internal_compile_11) || $__internal_compile_11 instanceof ArrayAccess ? ($__internal_compile_11[$context["column_index"]] ?? null) : null), "html", null, true);
            echo "\">
                </td>
              </tr>
            ";
        }
        $_parent = $context['_parent'];
        unset($context['_seq'], $context['_iterated'], $context['_key'], $context['column_index'], $context['_parent'], $context['loop']);
        $context = array_intersect_key($context, $_parent) + $_parent;
        // line 92
        echo "          </tbody>
        </table>
      </div>
      <div id=\"gis_editor\"></div>
      <div id=\"popup_background\"></div>
    </fieldset>

    <div id=\"searchoptions\"";
        // line 99
        if ((($context["default_sliders_state"] ?? null) != "disabled")) {
            // line 100
            echo (((($context["default_sliders_state"] ?? null) == "closed")) ? (" style=\"display: none; overflow:auto;\"") : (""));
            echo " class=\"pma_auto_slider\" title=\"";
            echo _gettext("Options");
            echo "\"";
        }
        // line 101
        echo ">

    ";
        // line 104
        echo "    <fieldset id=\"fieldset_select_fields\">
      <legend>
        ";
        // line 106
        echo _gettext("Select columns (at least one):");
        // line 107
        echo "      </legend>
      <select class=\"resize-vertical\" name=\"columnsToDisplay[]\" size=\"";
        // line 108
        echo twig_escape_filter($this->env, min(twig_length_filter($this->env, ($context["column_names"] ?? null)), 10), "html", null, true);
        echo "\" multiple>
        ";
        // line 109
        $context['_parent'] = $context;
        $context['_seq'] = twig_ensure_traversable(($context["column_names"] ?? null));
        foreach ($context['_seq'] as $context["_key"] => $context["each_field"]) {
            // line 110
            echo "          <option value=\"";
            echo twig_escape_filter($this->env, $context["each_field"], "html", null, true);
            echo "\" selected>
            ";
            // line 111
            echo twig_escape_filter($this->env, $context["each_field"], "html", null, true);
            echo "
          </option>
        ";
        }
        $_parent = $context['_parent'];
        unset($context['_seq'], $context['_iterated'], $context['_key'], $context['each_field'], $context['_parent'], $context['loop']);
        $context = array_intersect_key($context, $_parent) + $_parent;
        // line 114
        echo "      </select>
      <input type=\"checkbox\" name=\"distinct\" value=\"DISTINCT\" id=\"oDistinct\">
      <label for=\"oDistinct\">DISTINCT</label>
    </fieldset>

    ";
        // line 120
        echo "    <fieldset id=\"fieldset_search_conditions\">
      <legend>
        <em>";
        // line 122
        echo _gettext("Or");
        echo "</em>
        ";
        // line 123
        echo _gettext("Add search conditions (body of the \"where\" clause):");
        // line 124
        echo "      </legend>
      ";
        // line 125
        echo \PhpMyAdmin\Html\MySQLDocumentation::show("Functions");
        echo "
      <input type=\"text\" name=\"customWhereClause\" class=\"textfield\" size=\"64\">
    </fieldset>

    ";
        // line 130
        echo "    <fieldset id=\"fieldset_limit_rows\">
      <legend>";
        // line 131
        echo _gettext("Number of rows per page");
        echo "</legend>
      <input type=\"number\" name=\"session_max_rows\" min=\"1\" value=\"";
        // line 132
        echo twig_escape_filter($this->env, ($context["max_rows"] ?? null), "html", null, true);
        echo "\" class=\"textfield\" required>
    </fieldset>

    ";
        // line 136
        echo "    <fieldset id=\"fieldset_display_order\">
      <legend>";
        // line 137
        echo _gettext("Display order:");
        echo "</legend>
      <select name=\"orderByColumn\"><option value=\"--nil--\"></option>
        ";
        // line 139
        $context['_parent'] = $context;
        $context['_seq'] = twig_ensure_traversable(($context["column_names"] ?? null));
        foreach ($context['_seq'] as $context["_key"] => $context["each_field"]) {
            // line 140
            echo "          <option value=\"";
            echo twig_escape_filter($this->env, $context["each_field"], "html", null, true);
            echo "\">
            ";
            // line 141
            echo twig_escape_filter($this->env, $context["each_field"], "html", null, true);
            echo "
          </option>
        ";
        }
        $_parent = $context['_parent'];
        unset($context['_seq'], $context['_iterated'], $context['_key'], $context['each_field'], $context['_parent'], $context['loop']);
        $context = array_intersect_key($context, $_parent) + $_parent;
        // line 144
        echo "      </select>

      <div class=\"formelement\">
        <input type=\"radio\" name=\"order\" id=\"orderByAscRadio\" value=\"ASC\" checked>
        <label for=\"orderByAscRadio\">";
        // line 148
        echo _gettext("Ascending");
        echo "</label>
      </div>
      <div class=\"formelement\">
        <input type=\"radio\" name=\"order\" id=\"orderByDescRadio\" value=\"DESC\">
        <label for=\"orderByDescRadio\">";
        // line 152
        echo _gettext("Descending");
        echo "</label>
      </div>

    </fieldset>
    <div class=\"clearfloat\"></div>
    </div>
  </fieldset>

  <fieldset class=\"tblFooters\">
    <input class=\"btn btn-primary\" type=\"submit\" name=\"submit\" value=\"";
        // line 161
        echo _gettext("Go");
        echo "\">
  </fieldset>
</form>
<div id=\"sqlqueryresultsouter\"></div>
";
    }

    public function getTemplateName()
    {
        return "table/search/index.twig";
    }

    public function isTraitable()
    {
        return false;
    }

    public function getDebugInfo()
    {
        return array (  404 => 161,  392 => 152,  385 => 148,  379 => 144,  370 => 141,  365 => 140,  361 => 139,  356 => 137,  353 => 136,  347 => 132,  343 => 131,  340 => 130,  333 => 125,  330 => 124,  328 => 123,  324 => 122,  320 => 120,  313 => 114,  304 => 111,  299 => 110,  295 => 109,  291 => 108,  288 => 107,  286 => 106,  282 => 104,  278 => 101,  272 => 100,  270 => 99,  261 => 92,  249 => 88,  243 => 87,  236 => 86,  232 => 84,  227 => 83,  222 => 80,  216 => 77,  210 => 74,  207 => 73,  205 => 72,  202 => 71,  200 => 70,  198 => 68,  196 => 67,  192 => 65,  188 => 63,  179 => 60,  174 => 59,  171 => 58,  166 => 57,  163 => 56,  158 => 54,  155 => 53,  153 => 52,  150 => 51,  148 => 50,  145 => 49,  142 => 47,  138 => 46,  131 => 42,  127 => 41,  123 => 40,  119 => 39,  114 => 38,  108 => 36,  106 => 35,  99 => 30,  97 => 29,  89 => 24,  85 => 23,  81 => 22,  77 => 21,  69 => 16,  65 => 15,  57 => 10,  53 => 9,  45 => 4,  41 => 3,  37 => 1,);
    }

    public function getSourceContext()
    {
        return new Source("", "table/search/index.twig", "E:\\server\\Apache24\\htdocs\\phpMyAdmin\\templates\\table\\search\\index.twig");
    }
}
