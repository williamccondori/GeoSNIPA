<template>
  <el-aside width="auto" style="min-height: 100vh">
    <el-menu
      style="height: 100%; overflow-y: auto"
      :collapse="menuComprimido"
      :default-active="$route.path"
      :router="true"
      :style="{ width: menuComprimido ? 'auto' : '20rem' }"
    >
      <div v-if="!menuComprimido" style="padding: 0.5rem">
        <InformacionUsuarioCard />
      </div>
      <el-menu-item index="/administrador">
        <i class="el-icon-house" />
        <span>Inicio</span>
      </el-menu-item>
      <el-menu-item index="/administrador/capas-base">
        <i class="el-icon-map-location" />
        <span>Capas base</span>
      </el-menu-item>
      <el-menu-item index="/administrador/servicios-externos">
        <i class="el-icon-paperclip" />
        <span>Servicios externos</span>
      </el-menu-item>
      <el-menu-item index="/administrador/grupos-capas">
        <i class="el-icon-folder-opened" />
        <span>Grupos de capas</span>
      </el-menu-item>
      <el-menu-item index="/administrador/configuraciones">
        <i class="el-icon-setting" />
        <span>Configuraciones</span>
      </el-menu-item>
    </el-menu>
  </el-aside>
</template>

<script>
import InformacionUsuarioCard from "@/components/administrador/compartido/InformacionUsuarioCard.vue";
export default {
  components: {
    InformacionUsuarioCard,
  },
  data() {
    return {
      menuComprimido: false,
    };
  },
};
</script>
