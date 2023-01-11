<template>
  <el-drawer
    :size="400"
    :wrapper-closable="false"
    :visible="estaAbiertoRolDrawer"
    @close="cerrarRolDrawer"
  >
    <span slot="title">
      <b>Actualizar roles</b>
    </span>
    <el-form ref="referenciaFormulario" :model="formulario">
      <div>
        <el-form-item prop="esUsuario" label="Usuario:">
          <el-checkbox v-model="formulario.esUsuario" disabled />
        </el-form-item>
        <el-form-item prop="esAdministrador" label="Administrador:">
          <el-checkbox v-model="formulario.esAdministrador" />
        </el-form-item>
        <el-button
          type="success"
          icon="el-icon-check"
          style="width: 100%"
          @click="guardar()"
        >
          Actualizar roles
        </el-button>
      </div>
    </el-form>
  </el-drawer>
</template>

<script>
import { mapState, mapActions } from "vuex";

const formulario = {
  esUsuario: false,
  esAdministrador: false,
};

export default {
  data() {
    return {
      formulario: { ...formulario },
    };
  },
  computed: {
    ...mapState("administrador", ["estaAbiertoRolDrawer", "usuario"]),
  },
  watch: {
    estaAbiertoRolDrawer(value) {
      if (!value) {
        this.formulario = { ...formulario };
        this.$refs.referenciaFormulario.resetFields();
      } else {
        const roles = this.usuario?.roles;
        if (roles) {
          this.formulario.esUsuario = roles.includes("usuario");
          this.formulario.esAdministrador = roles.includes("administrador");
        }
      }
    },
  },
  methods: {
    ...mapActions("administrador", ["cerrarRolDrawer", "obtenerTodosUsuarios"]),
    guardar() {
      this.$refs.referenciaFormulario.validate(async (valid) => {
        if (valid) {
          try {
            await this.$axios.put(`/usuarios/${this.usuario.id}/roles/`, {
              ...this.formulario,
            });
            await this.obtenerTodosUsuarios();
            this.cerrarRolDrawer();
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
