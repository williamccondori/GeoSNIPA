<template>
  <el-container>
    <MenuLateralAside />
    <el-container>
      <el-main> <nuxt /> </el-main>
    </el-container>
  </el-container>
</template>

<script>
import MenuLateralAside from "@/components/administrador/compartido/MenuLateralAside.vue";
export default {
  components: {
    MenuLateralAside,
  },
};
</script>
