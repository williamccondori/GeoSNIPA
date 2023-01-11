<template>
  <el-drawer
    :size="400"
    :wrapper-closable="false"
    :visible="estaAbiertoUsuarioDrawer"
    @close="cerrarUsuarioDrawer"
  >
    <span slot="title">
      <b>{{ titulo }}</b>
    </span>
    <el-form ref="referenciaFormulario" :model="formulario">
      <el-form-item
        prop="email"
        label="Correo electrónico:"
        :rules="[
          {
            required: true,
            message: 'Ingrese el correo electrónico del usuario',
          },
          {
            type: 'email',
            message: 'Ingrese un correo electrónico válido',
          },
        ]"
      >
        <el-input
          v-model="formulario.email"
          placeholder="Ingrese el correo electrónico del usuario"
        />
      </el-form-item>
      <el-form-item
        prop="username"
        label="Usuario:"
        :rules="
          !esEdicion
            ? [
                {
                  required: true,
                  message: 'Ingrese el usuario',
                },
                {
                  pattern: /^[a-zA-Z0-9]+$/,
                  message: 'Ingrese un usuario válido',
                },
              ]
            : []
        "
      >
        <el-input
          v-model="formulario.username"
          :disabled="esEdicion"
          placeholder="Ingrese el usuario"
        />
      </el-form-item>
      <el-form-item
        prop="password"
        label="Contraseña:"
        :rules="
          !esEdicion
            ? [
                {
                  required: true,
                  message: 'Ingrese la contraseña del usuario',
                },
              ]
            : []
        "
      >
        <el-input
          v-model="formulario.password"
          :disabled="esEdicion"
          show-password
          placeholder="Ingrese la contraseña del usuario"
        />
      </el-form-item>
      <el-form-item prop="nombres" label="Nombres:">
        <el-input
          v-model="formulario.nombres"
          placeholder="Ingrese los nombres del usuario"
        />
      </el-form-item>
      <el-form-item prop="apellidos" label="Apellidos:">
        <el-input
          v-model="formulario.apellidos"
          placeholder="Ingrese los apellidos del usuario"
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
  email: "",
  username: "",
  password: "",
  nombres: undefined,
  apellidos: undefined,
  estaHabilitado: true,
};

export default {
  data() {
    return {
      formulario: { ...formulario },
    };
  },
  computed: {
    ...mapState("administrador", ["estaAbiertoUsuarioDrawer", "usuario"]),
    esEdicion() {
      return this.usuario !== undefined;
    },
    titulo() {
      return this.esEdicion ? "Actualizar usuario" : "Crear usuario";
    },
  },
  watch: {
    estaAbiertoUsuarioDrawer(value) {
      if (!value) {
        this.formulario = { ...formulario };
        this.$refs.referenciaFormulario.resetFields();
      } else {
        if (this.esEdicion && this.usuario) {
          this.formulario.email = this.usuario.email;
          this.formulario.username = this.usuario.username;
          this.formulario.nombres = this.usuario.nombres;
          this.formulario.apellidos = this.usuario.apellidos;
          this.formulario.estaHabilitado = this.usuario.estaHabilitado;
        }
      }
    },
  },
  methods: {
    ...mapActions("administrador", [
      "cerrarUsuarioDrawer",
      "obtenerTodosUsuarios",
    ]),
    guardar() {
      this.$refs.referenciaFormulario.validate(async (valid) => {
        if (valid) {
          try {
            if (this.esEdicion) {
              await this.$axios.put(`/usuarios/${this.usuario.id}`, {
                ...this.formulario,
              });
            } else {
              await this.$axios.post("/usuarios", { ...this.formulario });
            }
            await this.obtenerTodosUsuarios();
            this.cerrarUsuarioDrawer();
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
