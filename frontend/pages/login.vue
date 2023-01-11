<template>
  <el-container>
    <el-main>
      <div style="display: flex; justify-content: center">
        <el-card style="width: 25rem">
          <IniciarSesionForm />
        </el-card>
      </div>
    </el-main>
  </el-container>
</template>

<script>
import IniciarSesionForm from "@/components/administrador/IniciarSesionForm.vue";
export default {
  components: {
    IniciarSesionForm,
  },
};
</script>
