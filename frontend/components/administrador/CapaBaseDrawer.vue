<template>
  <el-drawer
    :size="400"
    :wrapper-closable="false"
    :visible="estaAbiertoCapaBaseDrawer"
    @close="cerrarCapaBaseDrawer"
  >
    <span slot="title">
      <b>{{ titulo }}</b>
    </span>
    <el-form ref="referenciaFormulario" :model="formulario">
      <el-form-item
        prop="nombre"
        label="Nombre:"
        :rules="[
          {
            required: true,
            message: 'Ingrese el nombre de la capa base',
          },
        ]"
      >
        <el-input
          v-model="formulario.nombre"
          placeholder="Ingrese el nombre de la capa base"
        />
      </el-form-item>
      <el-form-item
        prop="url"
        label="URL:"
        :rules="[
          {
            required: true,
            message: 'Ingrese la URL de la capa base',
          },
        ]"
      >
        <el-input
          v-model="formulario.url"
          placeholder="Ingrese la URL de la capa base"
        />
      </el-form-item>
      <el-form-item
        prop="atribucion"
        label="Atribución:"
        :rules="[
          {
            required: true,
            message: 'Ingrese la atribución de la capa base',
          },
        ]"
      >
        <el-input
          v-model="formulario.atribucion"
          placeholder="Ingrese la atribución de la capa base"
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
          @click="guardar()"
        >
          {{ titulo }}
        </el-button>
      </div>
    </el-form>
  </el-drawer>
</template>

<script>
import { mapState, mapActions } from "vuex";

const formulario = {
  nombre: "",
  url: "",
  atribucion: "",
  estaHabilitado: true,
};

export default {
  data() {
    return {
      formulario: { ...formulario },
    };
  },
  computed: {
    ...mapState("administrador", ["estaAbiertoCapaBaseDrawer", "capaBase"]),
    esEdicion() {
      return this.capaBase !== undefined;
    },
    titulo() {
      return this.esEdicion ? "Actualizar capa base" : "Crear capa base";
    },
  },
  watch: {
    estaAbiertoCapaBaseDrawer(value) {
      if (!value) {
        this.formulario = { ...formulario };
        this.$refs.referenciaFormulario.resetFields();
      } else {
        if (this.esEdicion && this.capaBase) {
          this.formulario.nombre = this.capaBase.nombre;
          this.formulario.url = this.capaBase.url;
          this.formulario.atribucion = this.capaBase.atribucion;
          this.formulario.estaHabilitado = this.capaBase.estaHabilitado;
        }
      }
    },
  },
  methods: {
    ...mapActions("administrador", [
      "cerrarCapaBaseDrawer",
      "obtenerTodosCapasBase",
    ]),
    guardar() {
      this.$refs.referenciaFormulario.validate(async (valid) => {
        if (valid) {
          try {
            if (this.esEdicion) {
              await this.$axios.put(`/capas-base/${this.capaBase.id}`, {
                ...this.formulario,
              });
            } else {
              await this.$axios.post("/capas-base", { ...this.formulario });
            }
            await this.obtenerTodosCapasBase();
            this.cerrarCapaBaseDrawer();
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
