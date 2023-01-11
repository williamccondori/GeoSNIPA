<template>
  <el-drawer
    :size="400"
    :wrapper-closable="false"
    :visible="estaAbiertoServicioExternoDrawer"
    @close="cerrarServicioExternoDrawer"
  >
    <span slot="title">
      <b>Agregar servicio externo</b>
    </span>
    <el-form ref="referenciaFormulario" :model="formulario" size="mini">
      <el-form-item
        prop="url"
        label="URL:"
        :rules="[
          {
            required: true,
            message: 'Ingrese la URL del servicio externo',
          },
        ]"
      >
        <el-input
          v-model="formulario.url"
          placeholder="Ingrese la URL del servicio externo"
        />
      </el-form-item>
      <el-form-item
        prop="nombre"
        label="Nombre:"
        :rules="[
          {
            required: true,
            message: 'Ingrese el nombre del servicio externo',
          },
        ]"
      >
        <el-input
          v-model="formulario.nombre"
          placeholder="Ingrese el nombre del servicio externo"
        />
      </el-form-item>
      <el-form-item prop="estaHabilitado" label="¿Está habilitado?:">
        <el-checkbox v-model="formulario.estaHabilitado" />
      </el-form-item>
      <div>
        <el-button
          type="success"
          icon="el-icon-check"
          style="width: 100%"
          @click="guardar"
        >
          Guardar
        </el-button>
      </div>
    </el-form>
  </el-drawer>
</template>

<script>
import { mapState, mapActions } from "vuex";

const formulario = {
  url: "",
  nombre: "",
  estaHabilitado: false,
};

export default {
  data() {
    return {
      formulario: { ...formulario },
    };
  },
  computed: {
    ...mapState("administrador", ["estaAbiertoServicioExternoDrawer"]),
  },
  watch: {
    estaAbiertoServicioExternoDrawer(value) {
      if (!value) {
        this.formulario = { ...formulario };
        this.$refs.referenciaFormulario.resetFields();
      }
    },
  },
  methods: {
    ...mapActions("administrador", ["cerrarServicioExternoDrawer"]),
    guardar() {
      this.$refs.referenciaFormulario.validate(async (valid) => {
        if (valid) {
          alert(JSON.stringify(this.formulario));
        }
      });
    },
  },
};
</script>
