<template>
  <el-form ref="referenciaFormulario" :model="formulario" label-width="12rem">
    <el-form-item
      prop="nombreEmpresa"
      label="Nombre de la empresa:"
      :rules="[
        {
          required: true,
          message: 'Ingrese el nombre de la empresa',
        },
      ]"
    >
      <el-input
        v-model="formulario.nombreEmpresa"
        placeholder="Ingrese el nombre de la empresa"
      />
    </el-form-item>
    <el-form-item
      prop="latitudInicial"
      label="Latitud inicial:"
      :rules="[
        {
          required: true,
          message: 'Ingrese la latitud inicial',
        },
      ]"
    >
      <el-input-number
        v-model="formulario.latitudInicial"
        :precision="6"
        :step="0.1"
        :min="-180"
        :max="180"
      />
    </el-form-item>
    <el-form-item
      prop="longitudInicial"
      label="Longitud inicial:"
      :rules="[
        {
          required: true,
          message: 'Ingrese la longitud inicial',
        },
      ]"
    >
      <el-input-number
        v-model="formulario.longitudInicial"
        :precision="6"
        :step="0.1"
        :min="-180"
        :max="180"
      />
    </el-form-item>
    <el-form-item
      prop="zoomInicial"
      label="Zoom inicial:"
      :rules="[
        {
          required: true,
          message: 'Ingrese el zoom inicial',
        },
      ]"
    >
      <el-input-number
        v-model="formulario.zoomInicial"
        placeholder="Zoom inicial"
        :min="0"
        :max="20"
      />
    </el-form-item>
    <el-form-item prop="capaBaseInicialId" label="Capa base inicial:">
      <el-select v-model="formulario.capaBaseInicialId" clearable>
        <el-option
          v-for="elemento in capasBase"
          :key="elemento.id"
          :label="elemento.nombre"
          :value="elemento.id"
        />
      </el-select>
    </el-form-item>
    <el-form-item
      prop="serviciosExternosActivosIds"
      label="Servicios externos activos:"
    >
      <el-select v-model="formulario.serviciosExternosActivosIds" multiple>
        <el-option
          v-for="elemento in serviciosExternos"
          :key="elemento.id"
          :label="elemento.nombre"
          :value="elemento.id"
        />
      </el-select>
    </el-form-item>
    <div>
      <el-button
        type="success"
        icon="el-icon-check"
        style="width: 100%"
        @click="guardar()"
      >
        Actualizar variables
      </el-button>
    </div>
  </el-form>
</template>

<script>
import { mapState, mapActions } from "vuex";

const formulario = {
  nombreEmpresa: "",
  latitudInicial: 0,
  longitudInicial: 0,
  zoomInicial: 0,
  capaBaseInicialId: undefined,
  serviciosExternosActivos: [],
};

export default {
  data() {
    return {
      formulario: { ...formulario },
    };
  },
  async fetch() {
    try {
      await this.obtenerTodosCapasBase();
      await this.actualizarFormulario();
    } catch (error) {
      this.$message.error(error);
    }
  },
  computed: {
    ...mapState("administrador", ["configuraciones", "capasBase"]),
  },
  methods: {
    ...mapActions("administrador", [
      "obtenerTodosConfiguraciones",
      "obtenerTodosCapasBase",
    ]),
    async actualizarFormulario() {
      await this.obtenerTodosConfiguraciones();
      const nombreEmpresa = this.configuraciones.find(
        (configuracion) => configuracion.nombre === "nombre_empresa"
      )?.valor;
      const latitudInicial = this.configuraciones.find(
        (configuracion) => configuracion.nombre === "latitud_inicial"
      )?.valor;
      const longitudInicial = this.configuraciones.find(
        (configuracion) => configuracion.nombre === "longitud_inicial"
      )?.valor;
      const zoomInicial = this.configuraciones.find(
        (configuracion) => configuracion.nombre === "zoom_inicial"
      )?.valor;
      const capaBaseInicialId = this.configuraciones.find(
        (configuracion) => configuracion.nombre === "capa_base_incial_id"
      )?.valor;
      const serviciosExternosActivos = this.configuraciones.find(
        (configuracion) => configuracion.nombre === "servicios_externos_activos"
      )?.valor;
      this.formulario.nombreEmpresa = nombreEmpresa;
      this.formulario.latitudInicial = latitudInicial;
      this.formulario.longitudInicial = longitudInicial;
      this.formulario.zoomInicial = zoomInicial;
      this.formulario.capaBaseInicialId = capaBaseInicialId;
      this.formulario.serviciosExternosActivos =
        serviciosExternosActivos?.split(",");
    },
    guardar() {
      this.$refs.referenciaFormulario.validate(async (valid) => {
        if (valid) {
          try {
            await this.$axios.put(`/configuraciones/`, {
              ...this.formulario,
            });
            await this.actualizarFormulario();
            this.$message.success("El proceso se ha completado correctamente");
          } catch (error) {
            this.$message.error(error);
          }
        }
      });
    },
  },
};
</script>
