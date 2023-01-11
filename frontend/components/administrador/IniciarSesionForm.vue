<template>
  <el-form ref="referenciaFormulario" :model="formulario">
    <el-form-item
      prop="username"
      :rules="[
        {
          required: true,
          message: 'Ingrese el nombre de usuario',
        },
      ]"
    >
      <el-input
        v-model="formulario.username"
        prefix-icon="el-icon-user"
        placeholder="Ingrese el nombre de usuario"
      />
    </el-form-item>
    <el-form-item
      prop="password"
      :rules="[
        {
          required: true,
          message: 'Ingrese la contraseña de usuario',
        },
      ]"
    >
      <el-input
        v-model="formulario.password"
        show-password
        prefix-icon="el-icon-key"
        placeholder="Ingrese la contraseña de usuario"
      />
    </el-form-item>
    <div>
      <el-button type="success" style="width: 100%" @click="iniciarSesion()">
        Iniciar sesión
      </el-button>
    </div>
    <div>
      <el-button
        type="text"
        style="width: 100%"
        @click="() => $router.push('/')"
      >
        Regresar al inicio
      </el-button>
    </div>
  </el-form>
</template>

<script>
const formulario = {
  username: "",
  password: "",
};

export default {
  data() {
    return {
      formulario: { ...formulario },
    };
  },
  methods: {
    iniciarSesion() {
      this.$refs.referenciaFormulario.validate(async (valid) => {
        if (valid) {
          try {
            const formulario = new FormData();
            formulario.append("username", this.formulario.username);
            formulario.append("password", this.formulario.password);
            await this.$auth.loginWith("local", {
              data: formulario,
            });
          } catch (error) {
            this.$message.error(error);
          }
        }
      });
    },
  },
};
</script>
